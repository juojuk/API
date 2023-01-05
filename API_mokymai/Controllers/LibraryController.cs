using API_mokymai.Data;
using API_mokymai.Models;
using API_mokymai.Models.Dto;
using API_mokymai.Repository.IRepository;
using API_mokymai.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Mime;

namespace API_mokymai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly IBookManager _bookManager;
        private readonly IBookRepository _bookRepo;
        private readonly IMeasureRepository _measureRepo;
        private readonly IReservationRepository _reservationRepo;
        private readonly IPersonRepository _personRepo;
        private readonly IBookWrapper _bookWrapper;
        private readonly IOpenRouteService _openRouteService;
        private readonly IShippingPriceRepo _shippingPriceRepo;
        private readonly IShippingOrderRepository _shippingOrderRepository;
        private readonly ILogger<LibraryController> _logger;

        public LibraryController(IBookManager bookManager, IBookRepository bookRepo, IMeasureRepository measureRepo, IReservationRepository reservationRepo, IPersonRepository personRepo, IBookWrapper bookWrapper, ILogger<LibraryController> logger, IOpenRouteService openRouteService, IShippingPriceRepo shippingPriceRepo, IShippingOrderRepository shippingOrderRepository)
        {
            _bookManager = bookManager;
            _bookRepo = bookRepo;
            _measureRepo = measureRepo;
            _reservationRepo = reservationRepo;
            _personRepo = personRepo;
            _bookWrapper = bookWrapper;
            _logger = logger;
            _openRouteService = openRouteService;
            _shippingPriceRepo = shippingPriceRepo;
            _shippingOrderRepository = shippingOrderRepository;
        }

        /// <summary>
        /// Fetches all registered books in the DB
        /// </summary>
        /// <returns>All books in DB</returns>
        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetBookDto>))]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Produces(MediaTypeNames.Application.Json)]
        //public ActionResult<List<GetBookDto>> Get()
        //{
        //    //return Ok(_bookManager.Get());
        //    return Ok(_bookRepo.GetAll().Select(b => _bookWrapper.Bind(b)).ToList());
        //}

        /// <summary>
        /// Fetch registered book with a specified ID from DB
        /// </summary>
        /// <param name="id">Requested book ID</param>
        /// <returns>Book with specified ID</returns>
        /// <response code="400">Customer bad request description</response>
        /// <remarks></remarks>
        [HttpGet("book/id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetBookDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<GetBookDto>> Get([FromQuery]int id)
        {
            if (id.GetType() != typeof(System.Int32))
            {
                _logger.LogInformation("Bad type of Book id {id}", id);
                return BadRequest();
            }

            // Tam, kad istraukti duomenis naudokite
            // First, FirstOrDefault, Single, SingleOrDefault, ToList
            var book = await _bookRepo.GetAsync(b => b.Id == id);

            if (book == null)
            {
                _logger.LogInformation("Book with id {id} not found", id);
                return NotFound();
            }

            return Ok(_bookWrapper.Bind(book));
        }

        [HttpGet("book/available")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetBookDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<bool>> GetAvailable([FromQuery] int id)
        {
            if (id.GetType() != typeof(System.Int32))
            {
                _logger.LogInformation("Bad type of Book id {id}", id);
                return BadRequest();
            }

            var book = await _bookRepo.GetAsync(b => b.Id == id);
            var reservations = await _reservationRepo.GetAllAsync(b => b.Id == id);


            if (book == null)
            {
                _logger.LogInformation("Book with id {id} not found", id);
                return NotFound();
            }


            return Ok(_bookManager.IsAvailableBook(book, reservations));
        }


        /// <summary>
        /// Searches book by ID in the DB
        /// </summary>
        /// <returns>Returns boolean status if book exists in the DB</returns>

        [HttpGet("book/exists")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> ExistsAsync([FromQuery] int id)
        {
            if (id.GetType() != typeof(System.Int32))
            {
                _logger.LogInformation("Bad type of Book id {id}", id);
                return BadRequest();
            }

            var foundBook = await _bookRepo.ExistAsync(id);

            if (!foundBook)
            {
                _logger.LogInformation("Book with id {id} not found", id);
                return NotFound();
            }

            return Ok(foundBook);
        }


        /// <summary>
        /// Fetches filtered books in the DB
        /// </summary>
        /// <returns>Filtered books in DB</returns>

        //[HttpGet("book/filter")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetBookDto>))]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Produces(MediaTypeNames.Application.Json)]
        //public async Task<ActionResult<List<GetBookDto>>> Filter([FromQuery]FilterBookRequest req)
        //{
        //    _logger.LogInformation("Getting book list with parameters {req}", JsonConvert.SerializeObject(req));

        //    IEnumerable<Book> entities = await _bookRepo.GetAllAsync();

        //    if (req.Pavadinimas != null)
        //        entities = entities.Where(x => x.Title == req.Pavadinimas);

        //    if (req.Autorius != null)
        //        entities = entities.Where(x => x.Author == req.Autorius);

        //    if (req.KnygosTipas != null)
        //        entities = entities.Where(x => x.Cover == Enum.Parse<ECoverType>(req.KnygosTipas));

        //    var model = entities?.Select(x => _bookWrapper.Bind(x));

        //    return Ok(model);
        //}

        /// <summary>
        /// Fetches all current reservations by person Id
        /// </summary>
        /// <returns>Filtered reservations in DB</returns>
        [HttpGet("reservations/current")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetCurrentReservationDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetCurrentReservations(int personId)
        {
            var reservations = await _reservationRepo.GetAllAsync(r => r.PersonId == personId);
            var currentReservations = _bookManager.GetCurrentReservations(reservations);
            return Ok(currentReservations);
        }

        [HttpGet("reservations/debts")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetDebtStatusDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetDebtStatus(int personId)
        {
            var reservations = await _reservationRepo.GetAllAsync(r => r.PersonId == personId);
            var measures = await _measureRepo.GetAllAsync();
            var currentDebts = _bookManager.GetCurrentDebts(measures, reservations);
            return Ok(currentDebts);
        }

        /// <summary>
        /// Fetches most popular author
        /// </summary>
        /// <returns></returns>
        [HttpGet("reservations/popularbookauthor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetMostPopularAuthor()
        {
            var reservations = await _reservationRepo.GetAllAsync();
            var popularAuthor = _bookManager.GetMostPopularAuthor(reservations);
            return Ok(popularAuthor);
        }


        /// <summary>
        /// Irasoma knyga i duomenu baze
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        /// <response code="400">paduodamos informacijos validacijos klaidos </response>
        [HttpPost("book/new")]
        [Authorize(Roles = "1")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GetBookDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Post([FromQuery] CreateBookDto book)
        {
            if (!Enum.TryParse(typeof(ECoverType), book.KnygosTipas, out _))
            {
                var validValues = Enum.GetNames(typeof(ECoverType));
                ModelState.AddModelError(nameof(book.KnygosTipas), $"Not valid value. Valid values are: {string.Join(", ", validValues)}");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Getting book list with wrong    parameters {book}", JsonConvert.SerializeObject(book));
                return ValidationProblem(ModelState);
            }

            var model = _bookWrapper.Bind(book);

            await _bookRepo.CreateAsync(model);

            return Created ("book/new", new { id = model.Id });
        }

        /// <summary>
        /// Irasoma papildoma pristatymo kaina i duomenu baze
        /// </summary>
        /// <param name="shippingPrice"></param>
        /// <returns></returns>
        /// <response code="400">paduodamos informacijos validacijos klaidos </response>
        [HttpPost("shippingPrice/new")]
        //[Authorize(Roles = "1")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateAdditShippingPriceDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Post([FromQuery] CreateAdditShippingPriceDto shippingPrice)
        {
            try
            {
                var shippingPriceModel = _bookWrapper.Bind(shippingPrice);
                await _shippingPriceRepo.CreateAsync(shippingPriceModel);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Shipping arguments {shippingPrice} are incorrect", shippingPrice);
                ModelState.AddModelError(nameof(shippingPrice), "Shipping arguments are incorrect");
                return ValidationProblem(ModelState);

            }

            return Created("shippingPrice/new", shippingPrice);

        }


        /// <summary>
        /// Irašomi rodikliai i duomenų bazę
        /// </summary>
        /// <param name="measure"></param>
        /// <returns></returns>
        /// <response code="401">Neautorizuotas vartotojas</response>
        [HttpPost("measure/new")]
        //[Authorize(Roles = "1")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateMeasureDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Post(CreateMeasureDto measure)
        {
            _logger.LogInformation("Getting measure with wrong parameters {measure}", JsonConvert.SerializeObject(measure));

            var model = _bookWrapper.Bind(measure);

            await _measureRepo.CreateAsync(model);

            return Created("PostMeasure", new { id = model.Id });
        }

        /// <summary>
        /// Vykdomas knygu isdavimas
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        /// <response code="400"></response>
        /// <response code="401">Neautorizuotas vartotojas</response>
        [HttpPost("reservation/new", Name = "PostReservation")]
        //[Authorize(Roles = "2")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateReservationDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Post([FromQuery]CreateReservationDto reservation)
        {
            var book = await _bookRepo.GetAsync(b => b.Id == reservation.KnygosId);
            var user = await _personRepo.GetAsync(p => p.Id == reservation.VartotojoId);
            var measures = await _measureRepo.GetAllAsync();
            int distance = 0;
            var additionalShippingPrices = await _shippingPriceRepo.GetAllAsync();
            var baseShippingPrice = measures.Last().BaseShippingPrice;


            if (book == null)
            {
                _logger.LogInformation("Bad Book id {reservation.KnygosId}", reservation.KnygosId);
                var validValues = _bookRepo.GetAllAsync().Result.Select(i => i.Id).ToArray();
                ModelState.AddModelError(nameof(reservation.KnygosId), $"Not valid value. Valid values are: {string.Join(", ", validValues)}");
            }

            if (user == null)
            {
                _logger.LogInformation("Bad type of User id {user.Id}", reservation.VartotojoId);
                var validValues = _personRepo.GetAllAsync().Result.Select(i => i.Id).ToArray();
                ModelState.AddModelError(nameof(reservation.VartotojoId), $"Not valid value. Valid values are: {string.Join(", ", validValues)}");
            }

            if (book != null)
            {
                var reservationsByBookId = await _reservationRepo.GetAllAsync(b => b.BookId == book.Id);
                var isAvailableBook = _bookManager.IsAvailableBook(book, reservationsByBookId);

                if (!isAvailableBook)
                {
                    _logger.LogInformation("Book id {book.Id} reservation is not available", book.Id);
                    ModelState.AddModelError(nameof(isAvailableBook), $"Book id {book.Id} reservation is not available");
                }
            }

            if (user != null)
            {
                var reservationsByPersonId = await _reservationRepo.GetAllAsync(b => b.PersonId == user.Id);
                var isAvailableReservation = _bookManager.IsAvailableReservation(measures, reservationsByPersonId);
                
                if (!isAvailableReservation)
                {
                    _logger.LogInformation("Reservation of books is not allowed");
                    ModelState.AddModelError(nameof(isAvailableReservation), "Reservation of books is not allowed");
                }
            }

            if (measures == null)
            {
                _logger.LogInformation("List of measures is empty");
                ModelState.AddModelError(nameof(measures), "List of measures is empty");
            }

            if (reservation.ShippingStatus == true)
            {
                try
                {
                    var coordinates = await _openRouteService.GetCoordinates(user);
                    distance = await _openRouteService.GetDistance(coordinates);
                    var isShippingAvailable = _bookManager.IsShippingAvailable(distance, baseShippingPrice, additionalShippingPrices);

                    if (!isShippingAvailable)
                    {
                        _logger.LogInformation("Shipping is not available");
                        ModelState.AddModelError(nameof(isShippingAvailable), "Shipping area is out of range");
                    }

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Coordinates and distance are not available");
                    ModelState.AddModelError(nameof(reservation.ShippingStatus), "Coordinates and distance are not available");
                    return ValidationProblem(ModelState);
                }
            }

            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var reservationModel = _bookWrapper.Bind(reservation, measures.Last().Id);

            await _reservationRepo.CreateAsync(reservationModel);

            if (reservation.ShippingStatus == true)
            {
                var shippingPrice = _bookManager.GetShippingPrice(distance, baseShippingPrice, additionalShippingPrices);
                await _shippingOrderRepository.CreateAsync(new ShippingOrder() { ConfirmationDate = null, ReservationId = reservationModel.Id });
            }

            return CreatedAtRoute("PostReservation", new { id = reservationModel.Id }, reservation);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]

        public async Task<IActionResult> Update([FromQuery] UpdateBookDto book)
        {
            if (book.Id == 0 || book == null)
            {
                return BadRequest();
            }

            var foundBook = await _bookRepo.GetAsync(d => d.Id == book.Id);

            if (foundBook == null)
            {
                return NotFound();
            }

            foundBook.Title = book.Pavadinimas;
            foundBook.Author = book.Autorius;
            foundBook.Cover = Enum.Parse<ECoverType>(book.KnygosTipas);
            foundBook.PublishYear = book.Isleista;

            await _bookRepo.UpdateAsync(foundBook);
            await _bookRepo.SaveAsync();

            return NoContent();
        }

        [HttpPatch("book/update/{id:int}", Name = "UpdatePartialBookDto")]
        //[Authorize(Roles = "1")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdatePartialBookByDto(int id, JsonPatchDocument<UpdateBookDto> request)
        {
            var gotBook = await _bookRepo.GetAsync(b => b.Id == id, tracked: false);

            if (gotBook == null)
            {
                _logger.LogInformation("Bad Book id {id}", id);
                return BadRequest();            
            }

            var foundBook = await _bookRepo.ExistAsync(b => b.Id == id);

            if (!foundBook)
            {
                _logger.LogInformation("Book with id {id} not found", id);
                return NotFound();
            }

            var bookDto = (UpdateBookDto)_bookWrapper.Bind(gotBook, 'U');

            request.ApplyTo(bookDto, ModelState);
            //request.ApplyTo(bookDto);

            var book = _bookWrapper.Bind(bookDto);

            await _bookRepo.UpdateAsync(book);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
                //return BadRequest();

            }
            return NoContent();
        }

        [HttpPatch("reservation/update/{id:int}", Name = "UpdatePartialReservationDto")]
        //[Authorize(Roles = "2")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdatePartialReservationByDto(int id, JsonPatchDocument<UpdateReservationDto> request)
        {
            var gotReservation = await _reservationRepo.GetAsync(b => b.Id == id, tracked: false);

            if (gotReservation == null)
            {
                _logger.LogInformation("Bad reservation id {id}", id);
                return BadRequest();
            }

            var foundReservation = await _reservationRepo.ExistAsync(b => b.Id == id);

            if (!foundReservation)
            {
                _logger.LogInformation("Reservation with id {id} not found", id);
                return NotFound();
            }

            var reservationDto = _bookWrapper.Bind(gotReservation);

            request.ApplyTo(reservationDto, ModelState);
            //request.ApplyTo(reservationDto);

            var reservation = _bookWrapper.Bind(reservationDto);

            await _reservationRepo.UpdateAsync(reservation);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
                //return BadRequest();

            }
            return NoContent();
        }


        [HttpDelete("book/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]

        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var book = await _bookRepo.GetAsync(d => d.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            await _bookRepo.RemoveAsync(book);

            return NoContent();
        }

    }
}

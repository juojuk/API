﻿using API_mokymai.Data;
using API_mokymai.Models;
using API_mokymai.Models.Dto;
using API_mokymai.Repository.IRepository;
using API_mokymai.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Mime;

namespace API_mokymai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //private readonly IBookManager _bookManager;
        //private readonly BookContext _db;
        private readonly IBookRepository _bookRepo;
        private readonly IBookWrapper _bookWrapper;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookRepository bookRepo, IBookWrapper bookWrapper, ILogger<BookController> logger)
        {
            _bookRepo = bookRepo;
            _bookWrapper = bookWrapper;
            _logger = logger;
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
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetBookDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<GetBookDto>> Get([FromQuery]int id)
        {
            //return Ok(_bookManager.Get(id));
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

        /// <summary>
        /// Searches book by ID in the DB
        /// </summary>
        /// <returns>Returns boolean status if book exists in the DB</returns>

        [HttpGet("exists")]
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

            var status = await _bookRepo.GetAllAsync();

            if (!status.Any(b => b.Id == id))
            {
                _logger.LogInformation("Book with id {id} not found", id);
                return NotFound();
            }

            return Ok(status);
        }


        /// <summary>
        /// Fetches filtered books in the DB
        /// </summary>
        /// <returns>Filtered books in DB</returns>

        [HttpGet("filter")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetBookDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<List<GetBookDto>>> Filter([FromQuery]FilterBookRequest req)
        {
            _logger.LogInformation("Getting book list with parameters {req}", JsonConvert.SerializeObject(req));

            IEnumerable<Book> entities = await _bookRepo.GetAllAsync();

            if (req.Pavadinimas != null)
                entities = entities.Where(x => x.Title == req.Pavadinimas);

            if (req.Autorius != null)
                entities = entities.Where(x => x.Author == req.Autorius);

            if (req.KnygosTipas != null)
                entities = entities.Where(x => x.Cover == Enum.Parse<ECoverType>(req.KnygosTipas));

            var model = entities?.Select(x => _bookWrapper.Bind(x));

            return Ok(model);
        }
        /// <summary>
        /// Irasoma knyga i duomenu baze
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        /// <response code="400">paduodamos informacijos validacijos klaidos </response>
        [HttpPost]
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

            Book model = new Book()
            {
                Title = book.Pavadinimas,
                Author = book.Autorius,
                Cover = Enum.Parse<ECoverType>(book.KnygosTipas),
                PublishYear = book.Isleista.Year,
            };

            await _bookRepo.CreateAsync(model);

            return CreatedAtRoute("filter", new { id = model.Id }, book);
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
            foundBook.PublishYear = book.Isleista.Year;

            await _bookRepo.UpdateAsync(foundBook);
            await _bookRepo.SaveAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
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

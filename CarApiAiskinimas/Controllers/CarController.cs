using CarApiAiskinimas.Models;
using CarApiAiskinimas.Models.Dto;
using CarApiAiskinimas.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mime;

/*aplikacija automobiliu registras
i���kiai:
+ 1. ka�kas kas visk� kontroliuoja. Tai bus Controller
+ 2. mums reikia kuo grei�iau atiduoti darbus front-end, t.y. reikalinga Swagger dokumentacija ir sukurti DTO kontrakt�
+ 3. nuspr�sti kokia yra biznio logika. Biznio modeliai
+ 4. duomen� baz�. EF, migracijos
+ 5. programa turi b�ti gera ir testuojama. Repository
+ 6. programa atvira modifikacijoms. DI + moodeli� Adapteris(Services)
7. programa turi tur�ti diagnostik� produkcin�je erdv�je. Logger
8. Validacijos. Attribute validations
9. Autentifikacija. JWT
10. Automatinis testavimas. Unit testai*/

namespace CarApiAiskinimas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {

        private readonly ILogger<CarController> _logger;
        private readonly ICarRepository _repository;
        private readonly ICarAdapter _adapter;


        public CarController(ILogger<CarController> logger, ICarRepository repository, ICarAdapter adapter)
        {
            _logger = logger;
            _repository = repository;
            _adapter = adapter;
        }

        /// <summary>
        /// Gaunamas
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCarResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult Get(int id)
        {
            if (!_repository.Exist(id))
            {
                _logger.LogInformation("Car with id {id} not found", id);
            };
                return NotFound();

            var entity = _repository.Get(id);
            var model = _adapter.Bind(entity);
                
            return Ok(model);
        }

        /// <summary>
        /// Gaunamas visas arba i�filtruotas db esan�i� automobili� s�ra�as
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetCarResult>))]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult Get([FromQuery]FilterCarRequest req)
        {
            _logger.LogInformation("Getting car list with parameters {req}", JsonConvert.SerializeObject(req));

            IEnumerable<Car> entities = _repository.All();

            if (req.Mark != null)
                entities = _repository.Find(x => x.Mark == req.Mark);

            if (req.Model != null)
                entities = _repository.Find(x => x.Model == req.Model);

            if (req.GearBox != null)
                entities = _repository.Find(x => x.GearBox == Enum.Parse<ECarGearBox>(req.GearBox));

            if (req.Fuel != null)
                entities = _repository.Find(x => x.Fuel == Enum.Parse<ECarFuel>(req.Fuel));

            var model  = entities.Select(x => _adapter.Bind(x));

            return Ok(model);
        }


        /// <summary>
        /// Ira�omas automobilis i duomen� baz�
        /// </summary>
        /// <returns></returns>
        /// <response code="400">paduodamos informacijos validacijos klaidos </response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Post([FromBody]PostCarRequest req)
        {
            var entity = _adapter.Bind(req);
            var id = _repository.Create(entity);

            return Created("PostCar", new {Id = id /*TODO*/});
        }

        /// <summary>
        /// Modifikuojamas automobilis duomen� baz�je
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Put(PutCarRequest req)
        {

            return NoContent();
        }

        /// <summary>
        /// Trinamas automobilis i� duomen� baz�s
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }


    }
}
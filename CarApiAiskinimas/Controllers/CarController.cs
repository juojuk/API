using CarApiAiskinimas.Models;
using CarApiAiskinimas.Models.Dto;
using CarApiAiskinimas.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

/*aplikacija automobiliu registras
iððûkiai:
+ 1. kaþkas kas viskà kontroliuoja. Tai bus Controller
+ 2. mums reikia kuo greièiau atiduoti darbus front-end, t.y. reikalinga Swagger dokumentacija ir sukurti DTO kontraktà
+ 3. nuspræsti kokia yra biznio logika. Biznio modeliai
+ 4. duomenø bazë. EF, migracijos
5. programa turi bûti gera ir testuojama. Repository
6. programa atvira modifikacijoms. DI
7. programa turi turëti diagnostikà produkcinëje erdvëje. Logger
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
        private readonly IRepository<Car> _repository;
        private readonly ICarAdapter _adapter;


        public CarController(ILogger<CarController> logger, IRepository<Car> repository, ICarAdapter adapter)
        {
            _logger = logger;
            _repository = repository;
            _adapter = adapter;
        }

        /// <summary>
        /// Gaunamas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetCarResult>))]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult Get()
        {
            var enities = _repository.All();
            var model = enities.Select(x => _adapter.Bind(x));
            return Ok(model);
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
            if(!_repository.Exist(id))
                return NotFound();

            var entity = _repository.Get(id);
            var model = _adapter.Bind(entity);
                return Ok(model);
        }

        /// <summary>
        /// Gaunamas
        /// </summary>
        /// <returns></returns>
        [HttpGet("filter")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetCarResult>))]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult Get([FromQuery]FilterCarRequest req)
        {
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
        /// Iraðomas automobilis i duomenø bazæ
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Post([FromBody]PostCarRequest req)
        {
            return Created("PostCar", new {id = 0 /*TODO*/});
        }

        /// <summary>
        /// Modifikuojamas automobilis duomenø bazëje
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Post(PutCarRequest req)
        {

            return NoContent();
        }

        /// <summary>
        /// Trinamas automobilis ið duomenø bazës
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
using CarApiAiskinimas.Models;
using CarApiAiskinimas.Models.Dto;
using CarApiAiskinimas.Repositories;
using CarApiAiskinimas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

/*aplikacija automobiliu registras
iððûkiai:
+ 1. kaþkas kas viskà kontroliuoja. Tai bus Controller
+ 2. mums reikia kuo greièiau atiduoti darbus front-end, t.y. reikalinga Swagger dokumentacija ir sukurti DTO kontraktà
+ 3. nuspræsti kokia yra biznio logika. Biznio modeliai
+ 4. duomenø bazë. EF, migracijos
+ 5. programa turi bûti gera ir testuojama. Repository
+ 6. programa atvira modifikacijoms. DI + moodeliø Adapteris(Services)
+ 7. programa turi turëti diagnostikà produkcinëje erdvëje. Logger
+ 8. Validacijos. Attribute validations
9. Autentifikacija. JWT
10. Automatinis testavimas. Unit testai
*/

namespace CarApiAiskinimas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CarController : ControllerBase
    {

        private readonly ILogger<CarController> _logger;
        private readonly ICarRepository _repository;
        private readonly ICarAdapter _adapter;

        public CarController(ILogger<CarController> logger,
            ICarRepository repository,
            ICarAdapter adapter)
        {
            _logger = logger;
            _repository = repository;
            _adapter = adapter;
        }



        /// <summary>
        /// Gaunamas duomenu bazeje esanciu automobiliu sarasas
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCarResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult Get(int id)
        {
            if (!_repository.Exist(id))
            {
                _logger.LogInformation("Car with id {id} not found", id);
                return NotFound();
            }

            var entity = _repository.Get(id);
            var model = _adapter.Bind(entity);

            return Ok(model);
        }


        /// <summary>
        /// Gaunamas visas arba isfiltruotas duomenu bazeje esanciu automobiliu sarasas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetCarResult>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult Get([FromQuery] FilterCarRequest req)
        {
            _logger.LogInformation("Getting car list with parameters {req}", JsonConvert.SerializeObject(req));

            IEnumerable<Car> entities = _repository.All().ToList();

            if (req.Mark != null)
                entities = entities.Where(x => x.Mark == req.Mark);

            if (req.Model != null)
                entities = entities.Where(x => x.Model == req.Model);

            if (req.GearBox != null)
                entities = entities.Where(x => x.GearBox == (ECarGearBox)Enum.Parse(typeof(ECarGearBox), req.GearBox));

            if (req.Fuel != null)
                entities = entities.Where(x => x.Fuel == (ECarFuel)Enum.Parse(typeof(ECarFuel), req.Fuel));

            var model = entities?.Select(x => _adapter.Bind(x));

            return Ok(model);
        }



        /*
    Built-in attributes 
   [ValidateNever]: Indicates that a property or parameter should be excluded from validation.
   [CreditCard]: Validates that the property has a credit card format. Requires jQuery Validation Additional Methods.
   [Compare]: Validates that two properties in a model match.
   [EmailAddress]: Validates that the property has an email format.
   [Phone]: Validates that the property has a telephone number format.
   [Range]: Validates that the property value falls within a specified range.
   [RegularExpression]: Validates that the property value matches a specified regular expression.
   [Required]: Validates that the field isn't null. See [Required] attribute for details about this attribute's behavior.
   [StringLength]: Validates that a string property value doesn't exceed a specified length limit.
   [Url]: Validates that the property has a URL format.
   [Remote]: Validates input on the client by calling an action method on the server. See [Remote] attribute for details about this attribute's behavior.
    */


        /// <summary>
        /// Irasomas automobilis i duomenu baze
        /// </summary>
        /// <returns></returns>
        /// <response code="400">paduodamos informacijos validacijos klaidos </response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Post(PostCarRequest req)
        {
            if (!Enum.TryParse(typeof(ECarGearBox), req.GearBox, out _))
            {
                var validValues = Enum.GetNames(typeof(ECarGearBox));
                ModelState.AddModelError(nameof(req.GearBox), $"Not valid value. Valid values are: {string.Join(", ", validValues)}");
            }
            if (!Enum.TryParse(typeof(ECarFuel), req.Fuel, out _))
            {
                var validValues = Enum.GetNames(typeof(ECarFuel));
                ModelState.AddModelError(nameof(req.Fuel), $"Not valid value. Valid values are: {string.Join(", ", validValues)}");
            }

            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }


            var entity = _adapter.Bind(req);
            var id = _repository.Create(entity);

            return Created("PostCar", new { Id = id });
        }


        /// <summary>
        /// Modifikuojamas automobilis duomenu bazeje
        /// </summary>
        /// <returns></returns>
        /// <response code="400">paduodamos informacijos validacijos klaidos </response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Put(PutCarRequest req)
        {
            if (!Enum.TryParse(typeof(ECarGearBox), req.GearBox, out _))
            {
                var validValues = Enum.GetNames(typeof(ECarGearBox));
                ModelState.AddModelError(nameof(req.GearBox), $"Not valid value. Valid values are: {string.Join(", ", validValues)}");
            }
            if (!Enum.TryParse(typeof(ECarFuel), req.Fuel, out _))
            {
                var validValues = Enum.GetNames(typeof(ECarFuel));
                ModelState.AddModelError(nameof(req.Fuel), $"Not valid value. Valid values are: {string.Join(", ", validValues)}");
            }

            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            if (!_repository.Exist(req.Id))
            {
                _logger.LogInformation("Car with id {id} not found", req.Id);
                return NotFound();
            }

            var entity = _adapter.Bind(req);
            _repository.Update(entity);

            return NoContent();
        }

        /// <summary>
        /// Trinamas automobilis is duomenu bazes
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {

            if (!_repository.Exist(id))
            {
                _logger.LogInformation("Car with id {id} not found", id);
                return NotFound();
            }
            var entity = _repository.Get(id);
            _repository.Remove(entity);

            return NoContent();
        }
    }
}
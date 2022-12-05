using CarApiAiskinimas.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

/*aplikacija automobiliu registras
iððûkiai:
1. kaþkas kas viskà kontroliuoja. Tai bus Controller
2. mums reikia kuo greièiau atiduoti darbus front-end, t.y. reikalinga Swagger dokumentacija ir sukurti DTO kontraktà
3. nuspræsti kokia yra biznio logika. Biznio modeliai ir servisai
4. duomenø bazë. EF, migracijos
5. programa atvira modifikacijoms. DI
6. programa turi bûti gera ir testuojama. Repository
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

        public CarController(ILogger<CarController> logger)
        {
            _logger = logger;
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
            return Ok();
        }
    }
}
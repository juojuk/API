using CarApiAiskinimas.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

/*aplikacija automobiliu registras
i���kiai:
1. ka�kas kas visk� kontroliuoja. Tai bus Controller
2. mums reikia kuo grei�iau atiduoti darbus front-end, t.y. reikalinga Swagger dokumentacija ir sukurti DTO kontrakt�
3. nuspr�sti kokia yra biznio logika. Biznio modeliai ir servisai
4. duomen� baz�. EF, migracijos
5. programa atvira modifikacijoms. DI
6. programa turi b�ti gera ir testuojama. Repository
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
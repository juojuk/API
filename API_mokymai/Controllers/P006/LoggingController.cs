using API_mokymai.Models.Dto;
using API_mokymai.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace API_mokymai.Controllers.P006
{
    /// <summary>
    /// 6 paskaita. Demonstracija dotNet logging funkcionalumui
    /// </summary>
    /// <returns>rezultatu masyvas</returns>
    /// <response code = "200">Teisingai ivykdoma loginimo logika ir gaunama informacija</response>
    /// <response code = "500">Vaje labai baisi klaida</response>

    [Route("api/[controller]")]
    [ApiController]
    public class LoggingController : ControllerBase
    {
        private readonly ILogger<LoggingController> _logger;
        private readonly IBadService _badService;
        private readonly IDalybaService _dalybaService;

        public LoggingController(ILogger<LoggingController> logger, IBadService badService, IDalybaService dalybaService)
        {
            _logger = logger;
            _badService = badService;
            _dalybaService = dalybaService;
        }

        /// <summary>
        /// Demonstruojamas bazinis visu loginimo lygiu funkcionalumas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((typeof(IEnumerable<GetLoggingResult>)),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult Get()
        {
            _logger.LogCritical("Betkokia critical informacija iš logerio");
            _logger.LogError("Betkokia error informacija iš logerio");
            _logger.LogWarning("Betkokia warning informacija iš logerio");


            _logger.LogInformation("Betkokia informacija iš logerio");
            _logger.LogDebug("Betkokia debug informacija iš logerio");
            _logger.LogTrace("Betkokia trace informacija iš logerio");


            return Ok();
        }

        /// <summary>
        /// Demonstruojamas serviso 'luzimo' situacijos loginimas
        /// </summary>
        /// <returns></returns>
        [HttpGet("BadService")]
        [ProducesResponseType(typeof(GetServiceResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]

        public IActionResult GetBadService()
        {
            _logger.LogInformation("BadService buvo iskviestas {time}", DateTime.Now);
            try
            {
                _badService.DoSomeWork();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Blogas servisas nulužo {0}", DateTime.Now);
            }
            return Ok(new GetServiceResult(555555));
        }

        /*
 * Užduotis
1. Prašykite GET metodą kuris per query priima du sveikus skaičius (Metodą tinkamai jį dokumentuokite)
2. Parašykite servisą kuris atlieka vieno skaičiaus dalybą iš kito. 
   Servise sąmoningai padarykite klaidą, kad vykdant dalybą iš 0 servisas nulūžta
3. Padarykite diagnostinį loginimą kuriame matytusi vartotojo elgsena ir įvesti skaičiai
4. Padarykite exception loginimą kuriame matytųsi gauta klaida, įvesti skaičiai ir klaidos data
 */
        /// <summary>
        /// Dalybos veiksmas
        /// </summary>
        /// <returns></returns>
        [HttpGet("Dalyba/{a:int}/{b:int}")]
        [ProducesResponseType(typeof(double),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]

        public IActionResult Get(int a, int b) 
        {
            _logger.LogInformation("DalybaService atliko dalybos veiksma {a} iš {b) {time}", a, b, DateTime.Now);
            try
            {
                _dalybaService.Dalyba(a, b);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "DalybaService {0} atliko dalybą iš nulio", DateTime.Now);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(_dalybaService.Dalyba(a, b));
        }


    }
}

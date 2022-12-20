using API_mokymai.Models.ApiModels;
using API_mokymai.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
/*
  USE CASE ID: 
    UC_PASISKOLINTI_KNYGA
  DESCRIPTION:
    Klientas pasiskolina knygą
  MAIN FLOW:
    1. klientas identifikuojasi sistemoje
    2. klientas pasirenka knygą iš nuomojamų knygų sąrašo 
       ('nuomojamų knygų sąrašas' yra knygos kurios yra 'knygų sąraše', bet 'išnuomotų knygų sąraše' nėra pažymėtos kaip 'sugadintos' arba 'prarastos')
    3. klientas pasirenka knygos pristatymo adresą (Lietuvoje) Sandelio vieta yra Vilnius
        3.1. Jei nuomos vieta yra 50km atsumu kaina sumažėja 2 Eur
     3.2. Jei nuomos vieta yra >50km <100km atsumu kaina nesikeičia
     3.3. Jei nuomos vieta yra >150km <300km atsumu kaina padidėja 2 Eur
     3.4. Jei nuomos vieta yra >300km atsumu - pristatymas negalimas.
    
     3.1. Jei nuomos vieta yra mieste kuriame gyvena virš 100k gyventojų, pristatymo kaina sumažėja 2 Eur
     3.2. Jei nuomos vieta yra mieste kuriame gyvena mažiau kaip 100k ir daugiau kaip 10k gyventojų, pristatymo kaina nesikeičia
     3.3. Jei nuomos vieta yra mieste kuriame gyvena mažiau kaip 10k gyventojų ir daugiau kaip 1k gyventojų, pristatymo kaina padidėja 2 Eur
     3.4. Jei nuomos vieta yra mieste kuriame gyvena mažiau kaip 1k gyventojų - pristatymas negalimas.
    4. klientas pasirenka kngos pristatymo/atsiėmimo laiką (arba atsiėmimo laiką)
     4.1. Jei laikas yra darbo metu (8:00-17:00) kaina sumažėja 1 Eur
     4.2. Jei laikas yra po darbo (17:00-21:00) kaina nesikeičia
     4.3. Jei laikas yra naktis (21:00-8:00) kaina padidėja 3 eur
    5. klientas apmoka už pristatymą/atsiėmimą (Bazinė kaina yra 5 Eur)
    6. sąskaita už pristatymą išsaugoma sąskaitų registre
    7. klientas gauna knygą
    8. biblioteka gauna patvirtinimą, kad knyga pristatyta klientui
    9. knyga ir ją išsinuomaves klientas įtraukiami į išnuomotų knygų sąrašą
  ALTERNATIVE FLOW 1:
    1. klientas identifikuojasi sistemoje
    2. Klientui pranešama, kad negali išsinuomoti knygos jeigu:
      2.1. Bibliotekoje pasirinktos knygos nėra (visos jau išnuomotos) 
      2.2. Neapmokėtų skolų už laiku negrąžintas knygas suma viršyja 10eur 
      2.3. Turi daugiau kaip 2 neapmokėtas skolas už laiku negrąžintas knygas
      2.4. Jau turi pasiskolines 5 knygas (viršyjo limitą) 
 
 */
namespace API_mokymai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakeApiController : ControllerBase
    {
        private readonly IFakeApiProxyService _service;
        private readonly ILogger<FakeApiController> _logger;

        public FakeApiController(IFakeApiProxyService service,
            ILogger<FakeApiController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookApiModel>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await _service.GetBooks();
                return Ok(res);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ivyko kazkas labai baisaus");
                throw;
            }

        }
    }
}
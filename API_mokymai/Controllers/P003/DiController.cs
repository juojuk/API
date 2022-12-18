using API_mokymai.Services.XServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_mokymai.Controllers.P003
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class DiController: ControllerBase
    {
        public readonly IOperationTransient _operationTransient;
        public readonly IOperationScoped _operationScoped;
        public readonly IOperationSingleton _operationSingleton;


        public DiController(IOperationTransient operationTransient, IOperationScoped operationScoped, IOperationSingleton operationSingleton)
        {
            _operationTransient = operationTransient;
            _operationScoped = operationScoped;
            _operationSingleton = operationSingleton;

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
               Transient = _operationTransient.GetOperationId(),
               Scoped = _operationScoped.GetOperationId(),
               Singleton = _operationSingleton.GetOperationId()
            });
        }
    }
}

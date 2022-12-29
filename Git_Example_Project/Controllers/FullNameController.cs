using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Git_Example_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FullNameController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { FullName = "Edvinas K." });
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P04_EF_Applying_To_API.Models.Dto;

namespace P04_EF_Applying_To_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        [HttpGet("dishes")]
        public ActionResult<IEnumerable<GetDishDTO>> GetDishes()
        {
            return Ok();
        }
    }
}

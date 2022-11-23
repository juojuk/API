using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P04_EF_Applying_To_API.Data;
using P04_EF_Applying_To_API.Models.Dto;

namespace P04_EF_Applying_To_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly RestaurantContext _db;

        public DishesController(RestaurantContext db)
        {
            _db = db;
        }

        [HttpGet("dishes")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetDishDTO>))]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<GetDishDTO>> GetDishes()
        {
            return Ok(_db.Dishes.Select(d => new GetDishDTO(d)).ToList());
        }
    }
}

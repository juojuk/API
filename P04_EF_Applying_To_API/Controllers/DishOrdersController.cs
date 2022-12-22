using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P04_EF_Applying_To_API.Models.Dto;
using P04_EF_Applying_To_API.Repository.IRepository;
using P04_EF_Applying_To_API.Services.Adapters.IAdapters;
using P04_EF_Applying_To_API.Services.IServices;
using System.Net.Mime;

namespace P04_EF_Applying_To_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishOrderController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        private readonly IDishOrderAdapter _dishOrderAdapter;
        private readonly ICookingService _cookingService;

        public DishOrderController(IUnitOfWork db, IDishOrderAdapter dishOrderAdapter, ICookingService cookingService)
        {
            _db = db;
            _dishOrderAdapter = dishOrderAdapter;
            _cookingService = cookingService;
        }

        [HttpGet("DishOrder", Name = "GetDishOrder")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetOrderResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetOrderResponse>> GetDishOrderById([FromQuery] GetOrderRequest model)
        {
            if (model.UserId == 0 || model.DishId == 0)
            {
                return BadRequest();
            }

            var isDishOrdered = await _db.DishOrder.ExistAsync(o => o.LocalUserId == model.UserId && o.DishId == model.DishId);

            if (!isDishOrdered)
            {
                return NotFound();
            }

            var dishOrder = await _db.DishOrder.GetAsync(o => o.LocalUserId == model.UserId && o.DishId == model.DishId);
            var response = _dishOrderAdapter.Bind(dishOrder);

            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateOrderResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<CreateOrderResponse>> CreateDishOrder([FromBody] CreateOrderRequest request)
        {
            if (request == null
                || request.UserId == 0
                || request.DishId == 0)
            {
                return BadRequest(request);
            }

            var userExists = await _db.User.IsRegisteredAsync(request.UserId);

            if (!userExists)
            {
                return NotFound(new { message = "User was not found" });
            }

            var dishExists = await _db.Dish.ExistAsync(d => d.DishId == request.DishId);

            if (!dishExists)
            {
                return NotFound(new { message = "Dish was not found" });
            }

            var orderedDish = await _db.Dish.GetAsync(d => d.DishId == request.DishId);

            var newDishOrder = _dishOrderAdapter.Bind(request);
            var response = _dishOrderAdapter.Bind(orderedDish);

            await _db.DishOrder.CreateAsync(newDishOrder);

            // Lets write a service
            await _cookingService.CookAsync(newDishOrder);

            return CreatedAtRoute("GetDishOrder", new { userId = request.UserId, dishId = request.DishId }, response);
        }
    }
}
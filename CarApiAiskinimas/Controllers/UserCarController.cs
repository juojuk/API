using CarApiAiskinimas.Models.Dto;
using CarApiAiskinimas.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CarApiAiskinimas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserCarController : ControllerBase
    {
        private readonly IUserCarRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<UserCarController> _logger;
        public UserCarController(IUserCarRepository repository,
            IHttpContextAccessor httpContextAccessor,
            ILogger<UserCarController> logger)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        [HttpGet("/api/user/{key}/cars")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetUserCarResponse>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult Get(int key)
        {
            var currentUserId = int.Parse(_httpContextAccessor.HttpContext.User.Identity.Name);
            if (currentUserId != key)
            {
                _logger.LogWarning("User {currentUserId} tried to access user {key} cars", currentUserId, key);
                return Forbid();
            }
            var cars = _repository.Get(key);
            return Ok(cars.Select(c => new GetUserCarResponseCar(c)));
        }
    }
}
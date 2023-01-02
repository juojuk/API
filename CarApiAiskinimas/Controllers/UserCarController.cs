using CarApiAiskinimas.Models;
using CarApiAiskinimas.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarApiAiskinimas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserCarController : ControllerBase
    {
        private readonly IUserCarRepository _repository;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserCarController(IUserCarRepository repository, IHttpContextAccessor contextAccessor)
        {
            _repository = repository;
            _contextAccessor = contextAccessor;
        }

        [HttpGet("/api/user/{key}/cars")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetCarResponse>))]
        public IActionResult Get(int key)
        {
            var cars = _repository.Get(key);
            return Ok(cars.Select(c => new GetCarResponse(c)));
        }
    }

    public class GetCarResponse
    {
        public GetCarResponse(Car car)
        {
            Id = car.Id;
            Mark = car.Mark;
            Model = car.Model;
            Year = car.Year;
            PlateNumber = car.PlateNumber;
            GearBox = car.GearBox;
            Fuel = car.Fuel;
        }

        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public string? PlateNumber { get; set; }
        public ECarGearBox GearBox { get; set; }
        public ECarFuel Fuel { get; set; }
    }
}

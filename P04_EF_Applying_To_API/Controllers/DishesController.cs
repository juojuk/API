using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P04_EF_Applying_To_API.Data;
using P04_EF_Applying_To_API.Models;
using P04_EF_Applying_To_API.Models.Dto;
using P04_EF_Applying_To_API.Repository.IRepository;

namespace P04_EF_Applying_To_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly IDishRepository _dishRepo;

        public DishesController(IDishRepository dishRepo)
        {
            _dishRepo = dishRepo;
        }
        /// <summary>
        /// Fetches all registered dishes in the DB
        /// </summary>
        /// <returns>All dishes in DB</returns>
        [HttpGet("dishes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetDishDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetDishDTO>>> GetDishes()
        {
            var dishes = await _dishRepo.GetAllAsync();
            return Ok(dishes
                .Select(d => new GetDishDTO(d))
                .ToList());
        }
        /// <summary>
        /// Fetch registered dish with a specified ID from DB
        /// </summary>
        /// <param name="id">Requested dish ID</param>
        /// <response>
        /// <returns>Dish with specified ID</returns>
        [HttpGet("dishes/{id:int}", Name = "GetDish")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetDishDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetDishDTO>> GetDishById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            // Tam, kad istraukti duomenis naudokite
            // First, FirstOrDefault, Single, SingleOrDefault, ToList
            var dish = await _dishRepo.GetAsync(d => d.DishId == id);

            if (dish == null)
            {
                return NotFound();
            }

            return Ok(new GetDishDTO(dish));
        }

        [HttpPost("dishes")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateDishDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateDishDTO>> CreateDish(CreateDishDTO dishDto)
        {
            if (dishDto == null)
            {
                return BadRequest();
            }

            Dish model = new Dish()
            {
                Country = dishDto.Country,
                SpiceLevel = dishDto.SpiceLevel,
                Type = dishDto.Type,
                Name = dishDto.Name,
                CreateDateTime = dishDto.CreateDateTime,
                ImagePath = dishDto.ImagePath
            };

            await _dishRepo.CreateAsync(model);

            return CreatedAtRoute("GetDish", new { id = model.DishId }, dishDto);
        }

        [HttpDelete("dishes/delete/{id:int}")]
        [Authorize(Roles = "super-admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        async Task<ActionResult> DeleteDish(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            var dish = await _dishRepo.GetAsync(d => d.DishId == id);

            if(dish == null)
            {
                return NotFound();
            }

            await _dishRepo.RemoveAsync(dish);

            return NoContent();
        }

        [HttpPut("dishes/update/{id:int}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> UpdateDishDto(int id, UpdateDishDTO updateDishDTO)
        {
            if(id == 0 || updateDishDTO == null)
            {
                return BadRequest();
            }

            var foundDish = await _dishRepo.GetAsync(d => d.DishId == id);

            if(foundDish == null){
                return NotFound();
            }
            foundDish.Name = updateDishDTO.Name;
            foundDish.ImagePath = updateDishDTO.ImagePath;
            foundDish.Type = updateDishDTO.Type;
            foundDish.SpiceLevel = updateDishDTO.SpiceLevel;
            foundDish.Country = updateDishDTO.Country;

            await _dishRepo.UpdateAsync(foundDish);

            return NoContent();
        }

    }
}
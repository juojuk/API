using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P02_Rest_Endpoints.Data;
using P02_Rest_Endpoints.Models;
using P02_Rest_Endpoints.Models.Dto;

namespace P02_Rest_Endpoints.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        /// <summary>
        /// This endpoint retrieves all stored foods
        /// </summary>
        /// <returns>Returns all stored foods</returns>
        [HttpGet("foods")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<FoodDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<FoodDTO>> GetAllFood()
        {
            var foods = FoodStore.foodList;

            return Ok(foods);
        }

        [HttpGet("foods/{id:int}", Name = "GetFood")]
        [ProducesResponseType(200, Type = typeof(FoodDTO))] // Same as StatusCodes.Status200OK
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<FoodDTO?> GetFoodById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var food = FoodStore.foodList
                .FirstOrDefault(f => f.Id == id);

            if (food == null)
            {
                return NotFound();
            }

            return Ok(food);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("foods/testing/{id:int}")]
        [ProducesResponseType(200, Type = typeof(FoodDTO))] // Same as StatusCodes.Status200OK
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<FoodDTO?> GetFoodByIdTesting(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var food = FoodStore.foodList
                .FirstOrDefault(f => f.Id == id);

            if (food == null)
            {
                return NotFound();
            }

            return Ok(food);
        }

        // foods/country -> Route dalis
        [HttpGet("foods/country")]
        [ProducesResponseType(200, Type = typeof(FoodDTO))] // Same as StatusCodes.Status200OK
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<FoodDTO?> GetFoodByNameAndCountry(string foodName, string country)
        {
            if (string.IsNullOrWhiteSpace(foodName) || string.IsNullOrWhiteSpace(country))
            {
                return BadRequest();
            }

            var food = FoodStore.foodList
                .FirstOrDefault(f => f.Name == foodName && f.Country == country);

            if (food == null)
            {
                return NotFound();
            }

            return Ok(food);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(FoodDTO))] // Same as StatusCodes.Status200OK
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<FoodDTO?> CreateFood(FoodDTO foodDTO)
        {
            if (foodDTO == null)
            {
                return BadRequest(foodDTO);
            }

            if (foodDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            // Auto increment
            int getLastFoodId = FoodStore.foodList // .Max(f => f.Id)
                .OrderByDescending(f => f.Id)
                .First().Id;

            foodDTO.Id = getLastFoodId + 1;

            FoodStore.foodList.Add(foodDTO);

            return CreatedAtRoute("GetFood", new { id = foodDTO.Id }, foodDTO);
        }

        [HttpDelete("foods/delete/{id:int}")]
        public void DeleteFood(int id)
        {
            var food = FoodStore.foodList
                .FirstOrDefault(f => f.Id == id);

            FoodStore.foodList.Remove(food);
        }

        [HttpPut("foods/update/{id:int}")]
        public void UpdateFood(int id, FoodDTO foodDTO)
        {
            var food = FoodStore.foodList
                .FirstOrDefault(f => f.Id == id);

            food.Name = foodDTO.Name;
            food.Weight = foodDTO.Weight;
            food.Country = foodDTO.Country;
        }
    }
}
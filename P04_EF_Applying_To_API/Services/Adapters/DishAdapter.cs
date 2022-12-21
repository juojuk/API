using P04_EF_Applying_To_API.Models;
using P04_EF_Applying_To_API.Models.Dto;
using P04_EF_Applying_To_API.Services.Adapters.IAdapters;

namespace P04_EF_Applying_To_API.Services.Adapters
{
    public class DishAdapter : IDishAdapter
    {
        public UpdateDishDTO Bind(Dish dish)
        {
            return new UpdateDishDTO
            {
                Country = dish.Country,
                ImagePath = dish.ImagePath,
                Name = dish.Name,
                SpiceLevel = dish.SpiceLevel,
                Type = dish.Type
            };
        }

        public Dish Bind(UpdateDishDTO updateDishDTO, int id)
        {
            return new Dish
            {
                Country = updateDishDTO.Country,
                ImagePath = updateDishDTO.ImagePath,
                Name = updateDishDTO.Name,
                SpiceLevel = updateDishDTO.SpiceLevel,
                Type = updateDishDTO.Type,
                DishId = id
            };
        }
    }
}

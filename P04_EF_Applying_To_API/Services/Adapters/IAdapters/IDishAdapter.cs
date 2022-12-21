using P04_EF_Applying_To_API.Models;
using P04_EF_Applying_To_API.Models.Dto;

namespace P04_EF_Applying_To_API.Services.Adapters.IAdapters
{
    public interface IDishAdapter
    {
        UpdateDishDTO Bind(Dish dish);
        Dish Bind(UpdateDishDTO updateDishDTO, int id);
    }
}

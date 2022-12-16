using P04_EF_Applying_To_API.Models;
using P04_EF_Applying_To_API.Services.IServices;

namespace P04_EF_Applying_To_API.Services
{
    public class CookingService : ICookingService
    {
        private readonly ILogger<CookingService> _logger;
        public CookingService(ILogger<CookingService> logger)
        {
            _logger = logger;
        }
        public async Task CookAsync(DishOrder dishOrder)
        {
            CookDishAsync(2, dishOrder);
        }

        private async Task CookDishAsync(int cookingTimeSec, DishOrder dishOrder)
        {
            for(var i = 0; i <= 100; i += 20)
            {
                await Task.Delay(cookingTimeSec * 1000);
                _logger.LogInformation($"Cooking <{dishOrder.Dish.DishId}.{dishOrder.Dish.Name}> in progress.. {i}%/100%");
            }

            _logger.LogInformation($"Cooking <{dishOrder.Dish.DishId}.{dishOrder.Dish.Name}> complete");
        }
    }
}

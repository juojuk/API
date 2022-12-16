using P04_EF_Applying_To_API.Models;

namespace P04_EF_Applying_To_API.Services.IServices
{
    public interface ICookingService
    {
        Task CookAsync(DishOrder dishOrder);
    }
}

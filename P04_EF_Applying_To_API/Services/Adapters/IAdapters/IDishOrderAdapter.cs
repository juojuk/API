using P04_EF_Applying_To_API.Models;
using P04_EF_Applying_To_API.Models.Dto;

namespace P04_EF_Applying_To_API.Services.Adapters.IAdapters
{
    public interface IDishOrderAdapter
    {
        DishOrder Bind(CreateOrderRequest request);
        GetOrderResponse Bind(DishOrder dishOrder);
        CreateOrderResponse Bind(Dish dish);
    }
}

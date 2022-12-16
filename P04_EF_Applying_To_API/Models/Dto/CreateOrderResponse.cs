namespace P04_EF_Applying_To_API.Models.Dto
{
    public class CreateOrderResponse
    {
        public string DishName { get; set; }
        public string State { get; set; }
        public DateTime CookingFinnishDateTime { get; set; }
    }
}

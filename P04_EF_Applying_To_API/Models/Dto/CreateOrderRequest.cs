namespace P04_EF_Applying_To_API.Models.Dto
{
    public class CreateOrderRequest
    {
        public int UserId { get; set; }
        public int DishId { get; set; }
    }
}

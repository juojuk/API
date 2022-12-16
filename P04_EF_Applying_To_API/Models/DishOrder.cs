namespace P04_EF_Applying_To_API.Models
{
    public class DishOrder
    {
        public int DishOrderId { get; set; }
        public int LocalUserId { get; set; }
        public int DishId { get; set; }
        public virtual LocalUser LocalUser { get; set; }
        public virtual Dish Dish { get; set; }
    }
}

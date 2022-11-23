namespace P04_EF_Applying_To_API.Models
{
    public class RecipeItem
    {
        public int RecipeItemId { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}

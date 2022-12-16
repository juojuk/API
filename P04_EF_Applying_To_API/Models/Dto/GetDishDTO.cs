namespace P04_EF_Applying_To_API.Models.Dto
{
    public class GetDishDTO
    {
        public GetDishDTO(Dish dish)
        {
            Name = dish.Name;
            Type = dish.Type;
            SpiceLevel = dish.SpiceLevel;
            Country = dish.Country;
            RecipeItems = dish.RecipeItems
                .Select(ri => new GetRecipeItemDTO(ri))
                .ToList();
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public string SpiceLevel { get; set; }
        public string Country { get; set; }
        public List<GetRecipeItemDTO> RecipeItems { get; set; } = new List<GetRecipeItemDTO>();
    }
}
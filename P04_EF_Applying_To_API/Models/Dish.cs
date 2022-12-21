using P04_EF_Applying_To_API.Models.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P04_EF_Applying_To_API.Models
{
    public class Dish
    {
        public Dish() { }

        public Dish(CreateDishDTO createDishDTO)
        {
            Name = createDishDTO.Name;
            Type = createDishDTO.Type;
            SpiceLevel = createDishDTO.SpiceLevel;
            Country = createDishDTO.Country;
            ImagePath = createDishDTO.ImagePath;
            CreateDateTime = createDishDTO.CreateDateTime;
        }

        public Dish(int dishId, string name, string type, string spiceLevel, string country, string imagePath, DateTime createDateTime)
        {
            DishId = dishId;
            Name = name;
            Type = type;
            SpiceLevel = spiceLevel;
            Country = country;
            ImagePath = imagePath;
            CreateDateTime = createDateTime;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DishId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string? SpiceLevel { get; set; }
        public string Country { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public virtual List<RecipeItem> RecipeItems { get; set; }
        public virtual List<DishOrder> DishOrders { get; set; }
    }
}

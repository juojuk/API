using Microsoft.EntityFrameworkCore;
using P04_EF_Applying_To_API.Models;

namespace P04_EF_Applying_To_API.Data
{
    public class RestaurantContext: DbContext
    {
        //Registruojamos lenetles
        //Prop pavadinimas = lentelės pavadinimas
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<RecipeItem> RecipeItems { get; set; }

    }
}

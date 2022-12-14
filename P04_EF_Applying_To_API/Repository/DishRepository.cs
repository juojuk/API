using P04_EF_Applying_To_API.Data;
using P04_EF_Applying_To_API.Models;
using P04_EF_Applying_To_API.Repository.IRepository;

namespace P04_EF_Applying_To_API.Repository
{
    public class DishRepository : Repository<Dish>, IDishRepository
    {
        private readonly RestaurantContext _db;

        public DishRepository(RestaurantContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Dish> UpdateAsync(Dish dish)
        {
            dish.UpdateDateTime = DateTime.Now;
            _db.Dishes.Update(dish);
            await _db.SaveChangesAsync();

            return dish;
        }
    }
}

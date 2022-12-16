using P04_EF_Applying_To_API.Data;
using P04_EF_Applying_To_API.Models;
using P04_EF_Applying_To_API.Repository.IRepository;

namespace P04_EF_Applying_To_API.Repository
{
    public class DishOrderRepository :  Repository<DishOrder>, IDishOrderRepository
    {
        private readonly RestaurantContext _db;

        public DishOrderRepository(RestaurantContext db) : base(db)
        {
            _db = db;
        }
    }
}

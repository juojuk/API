using P04_EF_Applying_To_API.Data;
using P04_EF_Applying_To_API.Repository.IRepository;

namespace P04_EF_Applying_To_API.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestaurantContext _db;

        public UnitOfWork(RestaurantContext db,
            IDishOrderRepository dishOrderRepository,
            IDishRepository dishRepository,
            IUserRepository userRepository)
        {
            _db = db;
            DishOrder = dishOrderRepository;
            Dish = dishRepository;
            User = userRepository;
        }

        public IDishOrderRepository DishOrder { get; private set; }

        public IDishRepository Dish { get; private set; }

        public IUserRepository User { get; private set; }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
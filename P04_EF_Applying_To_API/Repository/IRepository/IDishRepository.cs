using P04_EF_Applying_To_API.Models;

namespace P04_EF_Applying_To_API.Repository.IRepository
{
    public interface IDishRepository : IRepository<Dish>
    {
        Dish Update(Dish dish);
    }
}

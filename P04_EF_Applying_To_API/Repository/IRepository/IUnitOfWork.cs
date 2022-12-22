namespace P04_EF_Applying_To_API.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IDishOrderRepository DishOrder { get; }
        IDishRepository Dish { get; }
        IUserRepository User { get; }
        Task SaveAsync();
    }
}

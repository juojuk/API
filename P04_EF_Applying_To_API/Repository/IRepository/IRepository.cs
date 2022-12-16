using System.Linq.Expressions;

namespace P04_EF_Applying_To_API.Repository.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // CRUD
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, bool tracked = true);
        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> filter);
        Task CreateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        //Task<bool> ExistAsync(int id);
        Task SaveAsync();

    }
}

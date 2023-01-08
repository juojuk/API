using System.Linq.Expressions;

namespace dotNET_Baigiamasis.Repository.IRepository
{
    public interface ICommonRepo<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>>? filter, bool tracked = true);
        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> filter);

        Task CreateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task SaveAsync();
    }
}

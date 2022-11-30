using System.Linq.Expressions;

namespace P04_EF_Applying_To_API.Repository.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // CRUD
        List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null);
        TEntity Get(Expression<Func<TEntity, bool>> filter, bool tracked = true);
        void Create(TEntity entity);
        void Remove(TEntity entity);
        void Save();

    }
}

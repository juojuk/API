using CarApiAiskinimas.Models;
using System.Linq.Expressions;

namespace CarApiAiskinimas.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        IEnumerable<T> All();
        T Get(int id);
        int Create(T entity);
        void Update(T entity);
        void Remove(T entity);
        int Count();
        bool Exist(int id);
        public IEnumerable<Car> Find(Expression<Func<Car, bool>> predicate);

    }
}

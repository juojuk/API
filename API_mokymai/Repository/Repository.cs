using API_mokymai.Data;
using API_mokymai.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API_mokymai.Repository
{
    // 0 Setupinam lazy loadinga
    //      a. Isirasykite Proxies repo -> install-package Microsoft.EntityFrameworkCore.Proxies
    //      b. Pridekite virtual zodeli prie navigaciniu property
    //      c. Uzregistruokite konfiguracija Program.cs -> option.UseLazyLoadingProxies();
    // 1. Susikuriam Generic repo interface
    // 2. Susikuriam Generic repo
    // 3. Susikuriam Model repo pvz: DishRepository
    // 4. Susikuriam Model repo interface
    // 5. Uzregistruojam Dependency Injection Program.cs faile
    // 6. Injectinam repo i Controlleri
    // 7. Naudojam ir megaujames
    public class Repository<TEntity>: IRepository<TEntity> where TEntity: class
    {
        private readonly BookContext _db;
        private DbSet<TEntity> _dbSet;

        public Repository(BookContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
            Save();
        }

        public TEntity Get(Expression<Func<TEntity, bool>>? filter, bool tracked = true)
        {
            IQueryable<TEntity> query = _dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            query = query.Where(filter);

            return query.FirstOrDefault();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToList();
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
            Save();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

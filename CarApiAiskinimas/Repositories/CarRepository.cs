using CarApiAiskinimas.Database;
using CarApiAiskinimas.Models;
using System.Linq.Expressions;

namespace CarApiAiskinimas.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarContext _context;

        public CarRepository(CarContext context)
        {
            _context = context;
        }

        public IEnumerable<Car> All()
        {
            return _context.Cars;
        }


        public Car Get(int id)
        {
            return _context.Cars.First(x => x.Id == id);
        }

        public IEnumerable<Car> Find(Expression<Func<Car, bool>> predicate)
        {
            return _context.Cars.Where(predicate);
        }

        public int Count()
        {
            return _context.Cars.Count();
        }

        public bool Exist(int id)
        {
            return _context.Cars.Any(x => x.Id == id);
        }

        public int Create(Car entity)
        {
            _context.Cars.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public void Update(Car entity)
        {
            _context.Cars.Update(entity);
            _context.SaveChanges();
        }

        public void Remove(Car entity)
        {
            _context.Cars.Remove(entity);
            _context.SaveChanges();
        }


    }
}

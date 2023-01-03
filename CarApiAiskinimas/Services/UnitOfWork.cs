using CarApiAiskinimas.Database;
using CarApiAiskinimas.Repositories;

namespace CarApiAiskinimas.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarContext _db;

        public UnitOfWork(CarContext db, ICarRepository car, ICarAdapter carAdapter, ICarLeasingService carLeasing, IUserRepository user, IUserCarRepository userCar)
        {
            _db = db;
            Car = car;
            CarAdapter = carAdapter;
            CarLeasing = carLeasing;
            User = user;
            UserCar = userCar;
        }

        public ICarRepository Car { get; private set; }

        public ICarAdapter CarAdapter { get; private set; }

        public ICarLeasingService CarLeasing { get; private set; }

        public IUserRepository User { get; private set; }

        public IUserCarRepository UserCar { get; private set; }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}

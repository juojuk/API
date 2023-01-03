using CarApiAiskinimas.Repositories;

namespace CarApiAiskinimas.Services
{
    public interface IUnitOfWork
    {
        ICarRepository Car { get; }
        ICarAdapter CarAdapter { get;}
        ICarLeasingService CarLeasing { get; }
        IUserRepository User { get; }
        IUserCarRepository UserCar { get; }
        Task SaveAsync();
    }
}

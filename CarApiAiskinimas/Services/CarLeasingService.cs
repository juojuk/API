using CarApiAiskinimas.Repositories;

namespace CarApiAiskinimas.Services
{
    public class CarLeasingService : ICarLeasingService
    {
        private readonly ICarRepository _repository;

        public CarLeasingService(ICarRepository repository)
        {
            _repository = repository;
        }

        public decimal AddPrice(double price, double percent)
        {
            return (decimal)(price * (1 + percent / 100));
        }
        public bool CanLease(int carId)
        {
            //throw new NotImplementedException();
            throw new Exception();
        }
        public void ChangeYear(int carId, int year)
        {
            var car = _repository.Get(carId);
            //cia kazkokia logika
            car.Year = new DateTime(year, 1, 1);
            _repository.Update(car);
        }
    }
}

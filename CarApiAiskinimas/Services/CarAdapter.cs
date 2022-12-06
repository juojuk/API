using CarApiAiskinimas.Models;
using CarApiAiskinimas.Models.Dto;

namespace CarApiAiskinimas.Services
{
    public class CarAdapter: ICarAdapter
    {
        public GetCarResult Bind(Car car)
        {
            return new GetCarResult
            {
                Id = car.Id,
                Mark = car.Mark,
                Model = car.Model,
                Year = car.Year.ToString("yyyy-MM-dd"),
                PlateNumber = car.PlateNumber ?? "neregistruota",
                GearBox = car.GearBox.ToString(),
                Fuel = car.Fuel.ToString()
            };
        }
        public Car Bind(PostCarRequest car)
        {
            return new Car
            {
                Mark = car.Mark,
                Model = car.Model,
                Year = DateTime.Parse(car.Year),
                PlateNumber = car.PlateNumber ?? "neregistruota",
                GearBox = Enum.Parse<ECarGearBox>(car.GearBox),
                Fuel = Enum.Parse<ECarFuel>(car.Fuel)
            };
        }

        public Car Bind(PutCarRequest car)
        {
            return new Car
            {
                Id = car.Id,
                Mark = car.Mark,
                Model = car.Model,
                Year = DateTime.Parse(car.Year),
                PlateNumber = car.PlateNumber ?? "neregistruota",
                GearBox = Enum.Parse<ECarGearBox>(car.GearBox),
                Fuel = Enum.Parse<ECarFuel>(car.Fuel)
            };
        }

    }
}

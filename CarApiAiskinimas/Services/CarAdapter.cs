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
    }
}

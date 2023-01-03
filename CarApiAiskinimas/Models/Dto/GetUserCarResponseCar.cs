using CarApiAiskinimas.Models;

namespace CarApiAiskinimas.Models.Dto
{
    public class GetUserCarResponseCar
    {
        public GetUserCarResponseCar(Car car)
        {
            Id = car.Id;
            Mark = car.Mark;
            Model = car.Model;
            Year = car.Year;
            PlateNumber = car.PlateNumber;
            GearBox = car.GearBox;
            Fuel = car.Fuel;
        }

        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public string? PlateNumber { get; set; }
        public ECarGearBox GearBox { get; set; }
        public ECarFuel Fuel { get; set; }
    }
}
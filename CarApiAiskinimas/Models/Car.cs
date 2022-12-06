namespace CarApiAiskinimas.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public string? PlateNumber { get; set; }
        public ECarGearBox GearBox { get; set; }
        public ECarFuel Fuel { get; set; }
    }
}

namespace CarApiAiskinimas.Models.Dto
{
    public class FilterCarRequest
    {
        /// <summary>
        /// Automobilio gamintojo pavadinimas
        /// </summary>
        public string Mark { get; set; }
        public string Model { get; set; }
        /// <summary>
        /// Automobilio pavarų dėžės tipas. Galimos reikšmės Manual ir Automatic
        /// </summary>
        public string GearBox { get; set; }
        /// <summary>
        /// Automobilio kuro tipas. Galimos reikšmės Petrol, Diesel, Electric
        /// </summary>
        public string Fuel { get; set; }

    }
}

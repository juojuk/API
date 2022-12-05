namespace CarApiAiskinimas.Models.Dto
{
    public class PostCarRequest
    {
        /// <summary>
        /// Automobilio gamintojo pavadinimas
        /// </summary>
        public string Mark { get; set; }
        public string Model { get; set; }
        /// <summary>
        /// Automobilio pagaminimo metai formatu yyyy-MM-dd
        /// </summary>
        public string Year { get; set; }
        public string PlateNumber { get; set; }
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

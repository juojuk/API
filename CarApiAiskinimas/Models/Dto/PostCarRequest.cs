using System.ComponentModel.DataAnnotations;

namespace CarApiAiskinimas.Models.Dto
{
    public class PostCarRequest
    {
        /// <summary>
        /// Automobilio gamintojo pavadinimas
        /// </summary>
        [MaxLength(50,ErrorMessage = "Mark cannot be longer than 50 characters")]
        public string Mark { get; set; }

        [MaxLength(50, ErrorMessage = "Mark cannot be longer than 50 characters")]
        public string Model { get; set; }
        /// <summary>
        /// Automobilio pagaminimo metai formatu yyyy-MM-dd. Galimi metai nuo 1900-01-01 iki 2021-01-01
        /// </summary>
        [Range(typeof(DateTime), "1900-01-01", "2021-01-01", ErrorMessage = "Year must be between 1900-01-01 and 2021-01-01")]
        public string Year { get; set; }

        [MaxLength(20, ErrorMessage = "Mark cannot be longer than 20 characters")]

        public string PlateNumber { get; set; }
        /// <summary>
        /// Automobilio pavarų dėžės tipas. Galimos reikšmės Manual ir Automatic
        /// </summary>
        [MaxLength(15, ErrorMessage = "Mark cannot be longer than 15 characters")]
        public string GearBox { get; set; }
        /// <summary>
        /// Automobilio kuro tipas. Galimos reikšmės Petrol, Diesel, Electric
        /// </summary>
        [MaxLength(15, ErrorMessage = "Mark cannot be longer than 15 characters")]
        public string Fuel { get; set; }
    }

}

using System.ComponentModel.DataAnnotations;

namespace dotNET_Baigiamasis.Models.Dto
{
    public class RegistrationUpdate
    {
        [MaxLength(30, ErrorMessage = "FirstName cannot be longer than 30 characters")]
        public string FirstName { get; set; }

        [MaxLength(60, ErrorMessage = "LastName cannot be longer than 60 characters")]
        public string LastName { get; set; }

        [MaxLength(40, ErrorMessage = "Address cannot be longer than 40 characters")]
        public string Address { get; set; }

        [MaxLength(20, ErrorMessage = "City cannot be longer than 20 characters")]
        public string City { get; set; }

        [MaxLength(20, ErrorMessage = "Country cannot be longer than 20 characters")]
        public string Country { get; set; }

        public string? Password { get; set; }
    }
}

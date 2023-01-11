using System.ComponentModel.DataAnnotations;

namespace dotNET_Baigiamasis.Models.Dto
{
    public class RegistrationRequest
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}

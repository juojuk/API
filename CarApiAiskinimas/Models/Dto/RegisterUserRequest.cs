using System.ComponentModel.DataAnnotations;

namespace CarApiAiskinimas.Models.Dto
{
    public class RegisterUserRequest
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? Role { get; set; }

    }
}
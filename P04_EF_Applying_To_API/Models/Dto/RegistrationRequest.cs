namespace P04_EF_Applying_To_API.Models.Dto
{
    public class RegistrationRequest
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}

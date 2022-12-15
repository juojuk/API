namespace API_mokymai.Models.Dto
{
    public class RegistrationRequest
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}

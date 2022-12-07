namespace P04_EF_Applying_To_API.Models.Dto
{
    public class LoginResponse
    {
        public LocalUser? User { get; set; }
        public string Token { get; set; }

    }
}

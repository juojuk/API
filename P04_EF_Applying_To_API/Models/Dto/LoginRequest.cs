namespace P04_EF_Applying_To_API.Models.Dto
{
    public class LoginRequest
    {
        // Jei šitie duomenys sutaps, mes vartotojui atgal grąžinsime JWT
        public string Username { get; set; }
        public string Password { get; set; }


    }
}

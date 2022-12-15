namespace API_mokymai.Models.Dto
{
    public class LoginRequest
    {
        // Jei šitie duomenys sutaps, mes vartotojui atgal grąžinsime JWT
        public string Email { get; set; }
        public string Password { get; set; }


    }
}

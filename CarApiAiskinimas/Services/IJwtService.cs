namespace CarApiAiskinimas.Services
{
    public interface IJwtService
    {
        string GetJwtToken(int userId, string role);
    }
}
namespace P04_EF_Applying_To_API.Services.IServices
{
    public interface IJwtService
    {
        string GetJwtToken(int userId, string role);
    }
}
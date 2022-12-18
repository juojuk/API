namespace API_mokymai.Services.IServices
{
    public interface IJwtService
    {
        string GetJwtToken(string email, int roleId);
    }
}
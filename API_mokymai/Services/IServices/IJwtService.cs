namespace API_mokymai.Services.IServices
{
    public interface IJwtService
    {
        string GetJwtToken(int userId, int roleId);
    }
}
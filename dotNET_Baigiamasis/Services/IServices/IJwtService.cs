namespace dotNET_Baigiamasis.Services.IServices
{
    public interface IJwtService
    {
        string GetJwtToken(string email, int roleId);

    }
}

using CarApiAiskinimas.Models;

namespace CarApiAiskinimas.Repositories
{
    public interface IUserRepository
    {
        bool Exist(string userName);
        int Register(LocalUser user);
        bool TryLogin(string userName, string password, out LocalUser? user);
    }
}
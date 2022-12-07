using P04_EF_Applying_To_API.Models;
using P04_EF_Applying_To_API.Models.Dto;

namespace P04_EF_Applying_To_API.Repository.IRepository
{
    public interface IUserRepository
    {
        public bool IsUniqueUser(string username);
        public LoginResponse Login(LoginRequest loginRequest);
        public LocalUser Register(RegistrationRequest registrationRequest);
    }
}

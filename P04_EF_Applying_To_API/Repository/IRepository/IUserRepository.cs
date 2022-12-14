using P04_EF_Applying_To_API.Models;
using P04_EF_Applying_To_API.Models.Dto;

namespace P04_EF_Applying_To_API.Repository.IRepository
{
    public interface IUserRepository
    {
        public Task<bool> IsUniqueUserAsync(string username);
        public Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
        public Task<LocalUser> RegisterAsync(RegistrationRequest registrationRequest);
    }
}

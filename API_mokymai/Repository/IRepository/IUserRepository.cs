using API_mokymai.Models;
using API_mokymai.Models.Dto;

namespace API_mokymai.Repository.IRepository
{
    public interface IUserRepository
    {
        public Task<bool> IsUniqueUserAsync(string email);
        public Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
        public Task<Person> RegisterAsync(RegistrationRequest registrationRequest);
    }
}

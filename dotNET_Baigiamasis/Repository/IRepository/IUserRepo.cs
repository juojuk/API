using dotNET_Baigiamasis.Models;
using dotNET_Baigiamasis.Models.Dto;

namespace dotNET_Baigiamasis.Repository.IRepository
{
    public interface IUserRepo
    {
        public Task<bool> IsUniqueUserAsync(string email);
        public Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
        public Task<Person> RegisterAsync(RegistrationRequest registrationRequest);
    }
}

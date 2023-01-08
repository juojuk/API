using dotNET_Baigiamasis.Data;
using dotNET_Baigiamasis.Models;
using dotNET_Baigiamasis.Models.Dto;
using dotNET_Baigiamasis.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace dotNET_Baigiamasis.Repository
{
    public class UserRepo
    {
        private readonly BookfanasContext _db;
        private readonly IPasswordService _passwordService;
        private readonly IJwtService _jwtService;

        public UserRepo(BookfanasContext db, IPasswordService passwordService, IJwtService jwtService)
        {
            _db = db;
            _passwordService = passwordService;
            _jwtService = jwtService;
        }

        /// <summary>
        /// Should return a flag indicating if a user with a specified username already exists
        /// </summary>
        /// <param name="email">Registration email</param>
        /// <returns>A flag indicating if email already exists</returns>
        public async Task<bool> IsUniqueUserAsync(string email)
        {
            var user = _db.Persons.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            var inputPasswordBytes = Encoding.UTF8.GetBytes(loginRequest.Password);
            var user = await _db.Persons.FirstOrDefaultAsync(x => x.Email.ToLower() == loginRequest.Email.ToLower());

            if (user == null || !_passwordService.VerifyPasswordHash(loginRequest.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new LoginResponse
                {
                    Token = "",
                    Person = null
                };
            }

            var token = _jwtService.GetJwtToken(user.Email, user.RoleId);

            LoginResponse loginResponse = new()
            {
                Token = token,
                Person = user
            };

            loginResponse.Person.PasswordHash = null;

            return loginResponse;
        }
        public async Task<Person> RegisterAsync(RegistrationRequest registrationRequest)
        {
            _passwordService.CreatePasswordHash(registrationRequest.Password, out byte[] passwordHash, out byte[] passwordSalt);

            Person user = new()
            {
                Email = registrationRequest.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                RoleId = registrationRequest.RoleId,
            };

            _db.Persons.Add(user);
            await _db.SaveChangesAsync();
            user.PasswordHash = null;
            return user;
        }
    }
}

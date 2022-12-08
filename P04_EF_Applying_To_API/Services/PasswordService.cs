using P04_EF_Applying_To_API.Services.IServices;
using System.Security.Cryptography;
using System.Text;

namespace P04_EF_Applying_To_API.Services
{
    public class PasswordService: IPasswordService
    {
        /// <summary>
        /// Uzkoduojam/uz'hashinam slaptazodi
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA256();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA256(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(passwordHash);
        }
    }
}
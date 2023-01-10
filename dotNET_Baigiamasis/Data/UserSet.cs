using dotNET_Baigiamasis.Models;
using dotNET_Baigiamasis.Services;

namespace dotNET_Baigiamasis.Data
{
    public static class UserSet
    {
        private static readonly PasswordService pass = new PasswordService();

        private static readonly byte[][] passhmac = CreatePassword("admin");          

        private static List<Person> userList = new List<Person>()
        {
            new Person()
            {
                Id = 1,
                FirstName = " ",
                LastName = " ",
                Email = "admin@bookfanas.eu",
                Address = " ",
                City = " ",
                Country = " ",
                PasswordHash = passhmac[0],
                PasswordSalt = passhmac[1],
                RoleId = 1,
            }
        };

        public static List<Person> Users { get { return userList; } set { userList = value; } }

        private static byte[][] CreatePassword(string password)
        {
            pass.CreatePasswordHash(password, out byte[] hash, out byte[] salt);
            return new byte[][] { hash, salt };
        }

    }
}

using dotNET_Baigiamasis.Models;
using dotNET_Baigiamasis.Services.IServices;

namespace dotNET_Baigiamasis.Data
{
    public static class UserSet
    {
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
                PasswordHash = new byte[0],
                PasswordSalt = new byte[0],
                RoleId = 1,
            }
        };

        public static List<Person> Users { get { return userList; } set { userList = value; } }

    }
}

using dotNET_Baigiamasis.Models;

namespace dotNET_Baigiamasis.Data
{
    public static class RoleSet
    {
        private static List<Role> roleList = new List<Role>()
        {
            new Role(1, "admin"),
            new Role(2, "editor"),
            new Role(3, "viewer")
        };
        public static List<Role> Roles { get { return roleList; } set { roleList = value; } }

    }
}

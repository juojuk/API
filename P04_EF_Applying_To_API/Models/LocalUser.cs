namespace P04_EF_Applying_To_API.Models
{
    public class LocalUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
    }
}

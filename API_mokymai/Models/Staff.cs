namespace API_mokymai.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual Role Role { get; set; }
    }
}

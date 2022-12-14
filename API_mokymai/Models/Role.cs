namespace API_mokymai.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Member { get; set; }
        public virtual List<Person> Persons { get; set; }
        public virtual List<Staff> Staff { get; set; }

    }
}

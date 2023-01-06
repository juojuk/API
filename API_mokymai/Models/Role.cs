namespace API_mokymai.Models
{
    public class Role
    {
        public Role(int id, string member)
        {
            Id = id;
            Member = member;
        }

        public int Id { get; set; }
        public string Member { get; set; }
        public List<Person> Persons { get; set; }
    }

}

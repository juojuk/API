namespace P02_Rest_Endpoints.Models
{
    public class Sport
    {
        public Sport(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

    }
}

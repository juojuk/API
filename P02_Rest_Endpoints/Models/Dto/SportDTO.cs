namespace P02_Rest_Endpoints.Models
{
    public class SportDTO
    {
        public SportDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

    }
}

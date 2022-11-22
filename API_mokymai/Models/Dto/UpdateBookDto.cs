namespace API_mokymai.Models.Dto
{
    public class UpdateBookDto
    {
        public int Id { get; set; }
        public DateTime Isleista { get; set; }
        public string Autorius { get; set; }
        public string Pavadinimas { get; set; }
        public string  KnygosTipas { get; set; }
    }
}

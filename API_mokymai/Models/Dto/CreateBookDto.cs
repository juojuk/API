namespace API_mokymai.Models.Dto
{
    public class CreateBookDto
    {
        public string Pavadinimas { get; set; }
        public string Autorius { get; set; }
        public DateTime Isleista { get; set; }
        public string KnygosTipas { get; set; }
    }
}

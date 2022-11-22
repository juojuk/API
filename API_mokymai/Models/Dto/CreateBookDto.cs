namespace API_mokymai.Models.Dto
{
    public class CreateBookDto
    {
        public CreateBookDto()
        {
        }

        public CreateBookDto(string pavadinimas, string autorius, DateTime isleista, string knygosTipas)
        {
            Pavadinimas = pavadinimas;
            Autorius = autorius;
            Isleista = isleista;
            KnygosTipas = knygosTipas;
        }

        public string Pavadinimas { get; set; }
        public string Autorius { get; set; }
        public DateTime Isleista { get; set; }
        public string KnygosTipas { get; set; }
    }
}

namespace API_mokymai.Models.Dto
{
    public class UpdateBookDto
    {
        public UpdateBookDto()
        {
        }

        public UpdateBookDto(int id, DateTime isleista, string autorius, string pavadinimas, string knygosTipas)
        {
            Id = id;
            Isleista = isleista;
            Autorius = autorius;
            Pavadinimas = pavadinimas;
            KnygosTipas = knygosTipas;
        }

        public int Id { get; set; }
        public DateTime Isleista { get; set; }
        public string Autorius { get; set; }
        public string Pavadinimas { get; set; }
        public string  KnygosTipas { get; set; }
    }
}

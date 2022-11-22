namespace API_mokymai.Models.Dto
{
    public class FilterBookRequest
    {
        public FilterBookRequest()
        {
        }

        public FilterBookRequest(string pavadinimas, string autorius, string knygosTipas)
        {
            Pavadinimas = pavadinimas;
            Autorius = autorius;
            KnygosTipas = knygosTipas;
        }

        public string Pavadinimas { get; set; }
        public string Autorius { get; set; }
        public string KnygosTipas { get; set; }
    }
}

namespace CarApiAiskinimas.Models.Dto
{
    public class GetUserCarResponse
    {
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public string AsmensKodas { get; set; }

        public IList<GetUserCarResponseCar> Automobiliai { get; set; }
    }
}
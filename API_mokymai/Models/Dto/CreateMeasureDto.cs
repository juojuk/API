namespace API_mokymai.Models.Dto
{
    public class CreateMeasureDto
    {
        public int SkolosTrukmeDienomis { get; set; }
        public int NegrazintuKnyguSkaicius { get; set; }
        public int IsduotuKnyguSkaicius { get; set; }
        public decimal MinimaliSkolosSuma { get; set; }
        public decimal MaksimaliSkolosSuma { get; set; }
    }
}

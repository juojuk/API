namespace API_mokymai.Models.Dto
{
    public class GetDebtStatusDto
    {
        public int IsdavimoId { get; set; }
        public string IsdavimoDataNuo { get; set; }
        public string GrazinimoDataIki { get; set; }
        public string? FaktineGrazinimoData { get; set; }
        public int PradelstosDienos { get; set; }
        public decimal PriskaiciuotaSkola { get; set; }
        public decimal DiskontoSuma { get; set; }
        public decimal SkolosSuma { get; set; }
    }
}

namespace API_mokymai.Models.Dto
{
    public class UpdateReservationDto
    {
        public int Id { get; set; }
        public DateTime IsdavimoData { get; set; } 
        public DateTime? GrazinimoData { get; set; }
        public int VartotojoId { get; set; }
        public int KnygosId { get; set; }
        public int MeasureId { get; set; }
    }
}

namespace API_mokymai.Models
{
    public class AdditinionalShippingPrice
    {
        public int Id { get; set; }
        public int DistanceKm { get; set; }
        public decimal? AdditionalPrice { get; set; }
    }
}

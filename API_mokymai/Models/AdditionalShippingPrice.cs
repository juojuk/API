using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_mokymai.Models
{
    public class AdditionalShippingPrice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DistanceKmId { get; set; }
        public decimal? AdditionalPrice { get; set; }
    }
}

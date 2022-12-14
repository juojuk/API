using API_mokymai.Data;

namespace API_mokymai.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime CheckOutDateTime { get; set; }
        public DateTime? ReturnDateTime { get; set; }
        public int PersonId { get; set; }
        public int BookId { get; set; }
        public int MeasureId { get; set; }
        public virtual Person Person { get; set; }
        public virtual Book Book { get; set; }
        public virtual Measure Measure { get; set; }


    }
}

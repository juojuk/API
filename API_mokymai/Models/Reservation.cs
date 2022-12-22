using API_mokymai.Data;

namespace API_mokymai.Models
{
    public class Reservation
    {

        public Reservation()
        {
        }

        public Reservation(int id, DateTime checkOutDateTime, DateTime? returnDateTime, int personId, int bookId, int measureId)
        {
            Id = id;
            CheckOutDateTime = checkOutDateTime;
            ReturnDateTime = returnDateTime;
            PersonId = personId;
            BookId = bookId;
            MeasureId = measureId;
        }

        public int Id { get; set; }
        public DateTime CheckOutDateTime { get; set; } = DateTime.Now;
        public DateTime? ReturnDateTime { get; set; } = null;
        public int PersonId { get; set; }
        public int BookId { get; set; }
        public int MeasureId { get; set; }
        public virtual Person Person { get; set; }
        public virtual Book Book { get; set; }
        public virtual Measure Measure { get; set; }


    }
}

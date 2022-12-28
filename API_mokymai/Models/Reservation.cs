using API_mokymai.Data;

namespace API_mokymai.Models
{
    public class Reservation
    {
        public Reservation()
        {
        }

        public Reservation(int id, DateTime checkOutDateTime, DateTime? returnDateTime, int personId, int bookId, int measureId, bool reservationStatus)
        {
            Id = id;
            CheckOutDateTime = checkOutDateTime;
            ReturnDateTime = returnDateTime;
            PersonId = personId;
            BookId = bookId;
            MeasureId = measureId;
            ReservationStatus = reservationStatus;
        }

        public int Id { get; set; }
        public DateTime CheckOutDateTime { get; set; } = DateTime.Today;
        public DateTime? ReturnDateTime { get; set; } = null;
        public int PersonId { get; set; }
        public int BookId { get; set; }
        public int MeasureId { get; set; }
        public bool ReservationStatus { get; set; } = true;
        public virtual Person Person { get; set; }
        public virtual Book Book { get; set; }
        public virtual Measure Measure { get; set; }


    }
}

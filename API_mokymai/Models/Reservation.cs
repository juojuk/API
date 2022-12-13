using API_mokymai.Data;

namespace API_mokymai.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public Person Person { get; set; }
        public Book Book { get; set; }
        public EBorrowingStatus Status { get; set; }

    }
}

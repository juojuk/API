namespace API_mokymai.Models
{
    public class Measure
    {
        public int Id { get; set; }
        public int MaxBorrowingDays { get; set; }
        public int MaxOverdueBooks { get; set; }
        public int MaxBooksOnHand { get; set; }
        public decimal MinBorrowingFee { get; set; }
        public decimal MaxBorrowingFee { get; set; }
        public virtual List<Reservation> Reservations{ get; set; }
    }
}

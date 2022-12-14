namespace API_mokymai.Models
{
    public class Measure
    {
        public int Id { get; set; }
        public int WeeksOfBorrowing { get; set; }
        public int OverdueBorrowings { get; set; }
        public int ReservedBooksLimit { get; set; }
        public decimal MinBorrowingFee { get; set; }
        public decimal MaxBorrowingFee { get; set; }
        public virtual List<Reservation> Reservations{ get; set; }
    }
}

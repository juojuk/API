namespace API_mokymai.Models
{
    public class Measure
    {
        public Measure()
        {
        }

        //public Measure()
        //{
        //    Reservations = List<Reservation>();
        //}


        public Measure(int id, int maxBorrowingDays, int maxOverdueBooks, int maxBooksOnHand, decimal minBorrowingFee, decimal maxBorrowingFee, decimal borrowingFeeRatio)
        {
            Id = id;
            MaxBorrowingDays = maxBorrowingDays;
            MaxOverdueBooks = maxOverdueBooks;
            MaxBooksOnHand = maxBooksOnHand;
            MinBorrowingFee = minBorrowingFee;
            MaxBorrowingFee = maxBorrowingFee;
            BorrowingFeeRatio = borrowingFeeRatio;
        }

        public int Id { get; set; }
        public int MaxBorrowingDays { get; set; }
        public int MaxOverdueBooks { get; set; }
        public int MaxBooksOnHand { get; set; }
        public decimal MinBorrowingFee { get; set; }
        public decimal MaxBorrowingFee { get; set; }
        public decimal BorrowingFeeRatio { get; set; }
        public decimal BaseShippingPrice { get; set; }
        public virtual List<Reservation> Reservations{ get; set; }
    }
}

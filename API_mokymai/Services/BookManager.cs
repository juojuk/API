using API_mokymai.Data;
using API_mokymai.Models;
using API_mokymai.Models.Dto;
using API_mokymai.Repository;
using API_mokymai.Repository.IRepository;
using API_mokymai.Services.IServices;

namespace API_mokymai.Services
{
    public class BookManager : IBookManager
    {
        //public int GetActiveMeasureId(List<Measure> measures)
        //{
        //    return measures.Last().Id;
        //}

        public bool IsAvailableBook(Book book, List<Reservation> reservations)
        {
            return book.Quantity > reservations.Count(b => b.ReturnDateTime == null && b.BookId == book.Id) ? true : false;
        }

        public bool IsAvailableReservation(List<Measure> measures, List<Reservation> reservations)
        {
            var isMaxBooksOnHand = measures.Last().MaxBooksOnHand > GetNumberOfBooksOnHand(reservations) ? true : false;
            var isMoreOverDueBooks = GetNumberOfOverDueBooks(reservations) > measures.Last().MaxOverdueBooks ? true : false;
            var isMinBorrowingFee = GetBorrowingFee(reservations) > measures.Last().MinBorrowingFee ? true : false;
            return !(isMaxBooksOnHand || isMoreOverDueBooks || isMinBorrowingFee);
        }

        public int GetNumberOfBooksOnHand(List<Reservation> reservations)
        {
            return reservations.Count(b => b.ReturnDateTime == null);
        }

        public int GetNumberOfOverDueBooks(List<Reservation> reservations)
        {
            return reservations.Count(r => r.CheckOutDateTime.AddDays(r.Measure.MaxBorrowingDays) < DateTime.Today && r.ReturnDateTime == null);
        }

        public decimal GetBorrowingFee(List<Reservation> reservations)
        {
            double borrowingDays = 0;
            decimal borrowingFee = 0;

            foreach (var r in reservations)
            {
                var returnDateTime = r.ReturnDateTime.HasValue ? r.ReturnDateTime : DateTime.Now;

                if (r.CheckOutDateTime.AddDays(r.Measure.MaxBorrowingDays) < returnDateTime)
                {
                    borrowingDays = (returnDateTime - r.CheckOutDateTime.AddDays(r.Measure.MaxBorrowingDays)).Value.Days;
                    borrowingFee += (decimal)Math.Pow(borrowingDays, 2) * r.Measure.BorrowingFeeRatio;
                }

                borrowingFee = borrowingFee > r.Measure.MaxBorrowingFee ? r.Measure.MaxBorrowingFee : borrowingFee;
            }
            return borrowingFee;
        }

    }
}

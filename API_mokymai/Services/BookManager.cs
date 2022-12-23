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
        public int GetActiveMeasureId(List<Measure> measures)
        {
            return measures.Last().Id;
        }

        public bool IsAvailableBook(Book book, List<Reservation> reservations)
        {
            return book.Quantity > reservations.Count(b => b.ReturnDateTime == null && b.BookId == book.Id) ? true : false;
        }

        public bool IsAvailableReservation(List<Measure> measures, List<Reservation> reservations)
        {
            var activeMeasure = measures.Last();
            return activeMeasure.MaxBooksOnHand > reservations.Count(b => b.ReturnDateTime == null) ? true : false;
        }

        public int GetNumberOfOverDueBooks(List<Reservation> reservations)
        {
            return reservations.Count(r => r.CheckOutDateTime.AddDays(r.Measure.MaxBorrowingDays) > DateTime.Today && r.ReturnDateTime == null);
        }

        public decimal GetBorrowingFee(List<Reservation> reservations)
        {
            throw new NotImplementedException();
        }
    }
}

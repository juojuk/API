using API_mokymai.Models;
using API_mokymai.Models.Dto;

namespace API_mokymai.Services.IServices
{
    public interface IBookManager
    {
        bool IsAvailableBook(Book book, List<Reservation> reservations);
        bool IsAvailableReservation(List<Measure> measures, List<Reservation> reservations);
        int GetNumberOfBooksOnHand(List<Reservation> reservations);
        int GetNumberOfOverDueBooks(List<Reservation> reservations);
        decimal GetBorrowingFee(List<Measure> measures, List<Reservation> reservations);
        List<Reservation> GetCurrentReservations(List<Reservation> reservations);
    }
}
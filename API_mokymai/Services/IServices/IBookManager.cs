using API_mokymai.Models;
using API_mokymai.Models.Dto;

namespace API_mokymai.Services.IServices
{
    public interface IBookManager
    {
        bool IsAvailableBook(Book book, List<Reservation> reservations);
        int GetActiveMeasureId(List<Measure> measures);
        bool IsAvailableReservation(List<Measure> measures, List<Reservation> reservations);
        int GetNumberOfOverDueBooks(List<Reservation> reservations);
        decimal GetBorrowingFee(List<Reservation> reservations);
    }
}
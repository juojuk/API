using API_mokymai.Models;
using API_mokymai.Models.Dto;
using System.Collections;

namespace API_mokymai.Services.IServices
{
    public interface IBookManager
    {
        bool IsAvailableBook(Book book, List<Reservation> reservations);
        bool IsAvailableReservation(List<Measure> measures, List<Reservation> reservations);
        int GetNumberOfBooksOnHand(List<Reservation> reservations);
        int GetNumberOfOverDueBooks(List<Reservation> reservations);
        public decimal GetBorrowingFee(List<Measure> measures, List<Reservation>? reservations, out decimal calculatedFee);
        List<GetCurrentReservationDto> GetCurrentReservations(List<Reservation> reservations);
        public List<GetDebtStatusDto> GetCurrentDebts(List<Measure> measures, List<Reservation> reservations);
        List<GetMostPopularAuthorDto> GetMostPopularAuthor(List<Reservation> reservations);
        public bool GetShippingPrice(int distance, decimal baseShippingPrice, List<AdditinionalShippingPrice> additinionalShippingPrices, out decimal? shippingPrice);
    }
}
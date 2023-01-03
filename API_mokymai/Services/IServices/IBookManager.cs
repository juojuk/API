using API_mokymai.Models;
using API_mokymai.Models.Dto;
using System.Collections;

namespace API_mokymai.Services.IServices
{
    public interface IBookManager
    {
        public bool IsAvailableBook(Book book, List<Reservation> reservations);
        public bool IsAvailableReservation(List<Measure> measures, List<Reservation> reservations);
        public int GetNumberOfBooksOnHand(List<Reservation> reservations);
        public int GetNumberOfOverDueBooks(List<Reservation> reservations);
        public decimal GetBorrowingFee(List<Measure> measures, List<Reservation>? reservations, out decimal calculatedFee);
        public List<GetCurrentReservationDto> GetCurrentReservations(List<Reservation> reservations);
        public List<GetDebtStatusDto> GetCurrentDebts(List<Measure> measures, List<Reservation> reservations);
        public List<GetMostPopularAuthorDto> GetMostPopularAuthor(List<Reservation> reservations);
        public bool IsShippingAvailable(int distance, decimal baseShippingPrice, List<AdditionalShippingPrice> additionalShippingPrices);
        public decimal? GetShippingPrice(int distance, decimal baseShippingPrice, List<AdditionalShippingPrice> additionalShippingPrices);

    }
}
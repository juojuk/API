using API_mokymai.Data;
using API_mokymai.Models;
using API_mokymai.Models.Dto;
using API_mokymai.Repository;
using API_mokymai.Repository.IRepository;
using API_mokymai.Services.IServices;
using System.Collections;
using System.Collections.Generic;

namespace API_mokymai.Services
{
    public class BookManager : IBookManager
    {
        public bool IsAvailableBook(Book book, List<Reservation>? reservations)
        {
            return book.Quantity > reservations.Count(b => b.ReturnDateTime == null && b.BookId == book.Id) ? true : false;
        }

        public bool IsAvailableReservation(List<Measure> measures, List<Reservation>? reservations)
        {
            var isMaxBooksOnHand = measures.Last().MaxBooksOnHand <= GetNumberOfBooksOnHand(reservations) ? true : false;
            var isMoreOverDueBooks = GetNumberOfOverDueBooks(reservations) > measures.Last().MaxOverdueBooks ? true : false;
            var isMinBorrowingFee = GetBorrowingFee(measures, reservations, out _) > measures.Last().MinBorrowingFee ? true : false;
            return !(isMaxBooksOnHand || isMoreOverDueBooks || isMinBorrowingFee);
        }

        public int GetNumberOfBooksOnHand(List<Reservation>? reservations)
        {
            return reservations.Count(b => b.ReturnDateTime == null);
        }

        public int GetNumberOfOverDueBooks(List<Reservation>? reservations)
        {
            return reservations.Count(r => r.CheckOutDateTime.AddDays(r.Measure.MaxBorrowingDays) < DateTime.Today && r.ReturnDateTime == null);
        }

        public decimal GetBorrowingFee(List<Measure> measures, List<Reservation>? reservations, out decimal calculatedFee)
        {
            double borrowingDays;
            decimal borrowingFee = 0;
            calculatedFee = 0;


            foreach (var r in reservations)
            {
                if (r.CheckOutDateTime.AddDays(r.Measure.MaxBorrowingDays) < r.ReturnDateTime && r.DebtStatus)
                {
                    borrowingDays = (r.ReturnDateTime - r.CheckOutDateTime.AddDays(r.Measure.MaxBorrowingDays)).Value.Days;
                    calculatedFee += (decimal)Math.Pow(borrowingDays, 2) * r.Measure.BorrowingFeeRatio;
                }
            }

            borrowingFee = calculatedFee > measures.Last().MaxBorrowingFee ? measures.Last().MaxBorrowingFee : calculatedFee;

            return borrowingFee;
        }

        public List<GetCurrentReservationDto> GetCurrentReservations(List<Reservation> reservations)
        {
            return reservations.Where(r => r.ReturnDateTime == null).Select(cr => new GetCurrentReservationDto()
            {
                 IsdavimoData = cr.CheckOutDateTime.ToShortDateString(),
                 GrazinimoData = cr.CheckOutDateTime.AddDays(cr.Measure.MaxBorrowingDays).ToShortDateString(),
                 KnygosPavadinimas = cr.Book.Title,
                 KnygosAutorius = cr.Book.Author, 
            }).ToList();
        }

        public List<GetDebtStatusDto> GetCurrentDebts(List<Measure> measures, List<Reservation> reservations)
        {
            var borrowingFee = GetBorrowingFee(measures, reservations, out decimal calculatedFee);
            DateTime isdavimoDataNuo;
            DateTime grazinimoDataIki;
            DateTime faktineGrazinimoData;
            double pradelstosDienos;
            decimal priskaiciuotaSkola;
            decimal diskontoSuma;
            decimal skolosSuma;
            var debtStatusDtoList = new List<GetDebtStatusDto>() ;

            foreach (var r in reservations)
            {
                if(r.ReturnDateTime != null)
                {
                    isdavimoDataNuo = r.CheckOutDateTime;
                    grazinimoDataIki = r.CheckOutDateTime.AddDays(r.Measure.MaxBorrowingDays);
                    faktineGrazinimoData = r.ReturnDateTime.Value;
                    pradelstosDienos = grazinimoDataIki < faktineGrazinimoData ? (faktineGrazinimoData - grazinimoDataIki).Days : 0;
                    priskaiciuotaSkola = ((decimal)Math.Pow(pradelstosDienos, 2)) * r.Measure.BorrowingFeeRatio;
                    diskontoSuma = priskaiciuotaSkola - priskaiciuotaSkola * (!calculatedFee.Equals(0.0m) ? borrowingFee / calculatedFee : 0m);
                    skolosSuma = priskaiciuotaSkola - diskontoSuma;

                    debtStatusDtoList.Add(new GetDebtStatusDto()
                    {
                        IsdavimoId = r.Id,
                        IsdavimoDataNuo = isdavimoDataNuo.ToShortDateString(),
                        GrazinimoDataIki = grazinimoDataIki.ToShortDateString(),
                        FaktineGrazinimoData = faktineGrazinimoData.ToShortDateString(),
                        PradelstosDienos = (int)pradelstosDienos,
                        PriskaiciuotaSkola = priskaiciuotaSkola,
                        DiskontoSuma = diskontoSuma,
                        SkolosSuma = skolosSuma,
                    });
                }
            }

            return debtStatusDtoList;
        }

        public List<GetMostPopularAuthorDto> GetMostPopularAuthor(List<Reservation> reservations)
        {
            var groupedAuthors = reservations.GroupBy(r => r.Book.Author, r => r.Book.Author, (k, c) => new { Author = k, NumberOfAuthor = c.Count() });

            var mostPopularAuthorDto = groupedAuthors.OrderByDescending(l => l.NumberOfAuthor).Select(a => new GetMostPopularAuthorDto()
            {
                Author = a.Author,
                Rate = a.NumberOfAuthor,
            }).ToList();

            return mostPopularAuthorDto;
        }

        public bool GetShippingPrice(int distance, decimal baseShippingPrice, List<AdditinionalShippingPrice> additinionalShippingPrices, out decimal? shippingPrice)
        {
            var additionalshippingPrice = additinionalShippingPrices.Where(d => d.DistanceKm > distance).OrderBy(d => d.DistanceKm).FirstOrDefault().AdditionalPrice;

            if (additionalshippingPrice.HasValue)
            {
                shippingPrice = baseShippingPrice + additionalshippingPrice.Value;
                return true;
            }
            else
            {
                shippingPrice = null;
                return false;

            }

        }

    }
}

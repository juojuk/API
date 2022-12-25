using API_mokymai.Data;
using API_mokymai.Models;
using API_mokymai.Models.Dto;
using API_mokymai.Services.IServices;

namespace API_mokymai.Services
{
    public class BookWrapper: IBookWrapper
    {
        public GetBookDto Bind(Book book)
        {
            return new GetBookDto() 
            { 
                Id = book.Id, 
                PavadinimasIrAutorius = $"{ book.Cover } { book.Author }",
                LeidybosMetai = book.PublishYear
            };

        }

        public Object? Bind(Book book, char c)
        {
            switch (c)
            {
                case 'G':
                    return new GetBookDto()
                    {
                        Id = book.Id,
                        PavadinimasIrAutorius = $"{book.Cover} {book.Author}",
                        LeidybosMetai = book.PublishYear
                    };
                case 'U':
                    return new UpdateBookDto()
                    {
                        Id = book.Id,
                        Isleista = book.PublishYear,
                        Autorius = book.Author,
                        Pavadinimas = book.Title,
                        KnygosTipas = book.Cover.ToString(),
                        Kiekis = book.Quantity,

                    };
                default:
                    return null;
            }
        }


        public Book Bind(CreateBookDto book)
        {
            return new Book() 
            { 
               Title  = book.Pavadinimas,
               Author = book.Autorius,
               Cover = Enum.Parse<ECoverType>(book.KnygosTipas),
               PublishYear = book.Isleista.Year
            };
        }

        public Book Bind(UpdateBookDto book)
        {
            return new Book()
            {
                Id = book.Id,
                PublishYear = book.Isleista,
                Author = book.Autorius,
                Title = book.Pavadinimas,
                Cover = Enum.Parse<ECoverType>(book.KnygosTipas),
                Quantity = book.Kiekis,
            };
        }

        public Measure Bind(CreateMeasureDto measure)
        {
            return new Measure()
            {
                MaxBorrowingDays = measure.SkolosTrukmeDienomis,
                MaxOverdueBooks = measure.NegrazintuKnyguSkaicius,
                MaxBooksOnHand = measure.IsduotuKnyguSkaicius,
                MinBorrowingFee = measure.MinimaliSkolosSuma,
                MaxBorrowingFee = measure.MaksimaliSkolosSuma,
                BorrowingFeeRatio = measure.SkolosKoeficientas,
            };
        }

        public Reservation Bind(CreateReservationDto reservation, int measureId)
        {
            return new Reservation()
            {
                PersonId = reservation.VartotojoId,
                BookId = reservation.KnygosId,
                MeasureId = measureId,
            };
        }

        public UpdateReservationDto Bind(Reservation reservation)
        {
            return new UpdateReservationDto()
            {
                Id = reservation.Id,
                IsdavimoData = reservation.CheckOutDateTime,
                GrazinimoData = reservation.ReturnDateTime,
                VartotojoId = reservation.PersonId,
                KnygosId = reservation.BookId,
                MeasureId = reservation.MeasureId,
            };
        }

        public Reservation Bind(UpdateReservationDto reservation)
        {
            return new Reservation()
            {
                Id = reservation.Id,
                CheckOutDateTime = reservation.IsdavimoData,
                ReturnDateTime = reservation.GrazinimoData,
                PersonId = reservation.VartotojoId,
                BookId = reservation.KnygosId,
                MeasureId = reservation.MeasureId,
            };
        }
    }
}

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
                PublishYear = book.Isleista.Year,
                Author = book.Autorius,
                Title = book.Pavadinimas,
                Cover = Enum.Parse<ECoverType>(book.KnygosTipas)
            };
        }

    }
}

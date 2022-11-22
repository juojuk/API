using API_mokymai.Models;
using API_mokymai.Models.Dto;

namespace API_mokymai.Services
{
    public interface IBookWrapper
    {
        GetBookDto Bind(Book book);
        Book Bind(CreateBookDto book);
        Book Bind(UpdateBookDto book);
    }
}
using API_mokymai.Models;
using API_mokymai.Models.Dto;

namespace API_mokymai.Services.IServices
{
    public interface IBookManager
    {
        //List<GetBookDto> Get();
        //GetBookDto Get(int id);

        bool IsAvailableBook(Book book, List<Reservation> reservation);

    }
}
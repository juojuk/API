using API_mokymai.Models.Dto;

namespace API_mokymai.Services.IServices
{
    public interface IBookManager
    {
        //List<GetBookDto> Get();
        //GetBookDto Get(int id);

        int GetAvailable(int id);

    }
}
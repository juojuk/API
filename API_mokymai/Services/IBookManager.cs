using API_mokymai.Models.Dto;

namespace API_mokymai.Services
{
    public interface IBookManager
    {
        List<GetBookDto> Get();
    }
}
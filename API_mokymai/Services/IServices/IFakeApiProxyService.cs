using API_mokymai.Models.ApiModels;

namespace API_mokymai.Services.IServices
{
    public interface IFakeApiProxyService
    {
        Task<IEnumerable<BookApiModel>> GetBooks();
    }
}

using API_mokymai.Models;

namespace API_mokymai.Services.IServices
{
    public interface IOpenRouteService
    {
        Task<float[]> GetCoordinates(Person person);
        Task<int> GetDistance(float[]? coordinates);
    }
}
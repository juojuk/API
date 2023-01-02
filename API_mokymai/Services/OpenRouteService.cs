using API_mokymai.Models;
using API_mokymai.Models.ApiModels.OpenRouteServiceDirectionsApi;
using API_mokymai.Models.OpenRouteServiceGeocodeSearchApi;

namespace API_mokymai.Services
{
    public class OpenRouteService : IOpenRouteService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OpenRouteService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<float[]> GetCoordinates(Person person)
        {
            var httpClient = _httpClientFactory.CreateClient("OpenRouteServiceGeocodeSearchApi");
            var baseAddress = httpClient.BaseAddress + person.Address;
            var rootObject = await httpClient.GetFromJsonAsync<Geocoderootobject>(baseAddress);
            var coordinates = rootObject.features.Select(g => g.geometry.coordinates).First();
            return coordinates;
        }

        public async Task<int> GetDistance(float[] coordinates)
        {
            var httpClient = _httpClientFactory.CreateClient("OpenRouteServiceDirectionsApi");
            var baseAddress = httpClient.BaseAddress + string.Join(',', coordinates);
            var rootObject = await httpClient.GetFromJsonAsync<Directionsrootobject>(baseAddress);
            var distance = (int)rootObject.features.Select(p => p.properties.summary.distance/1000).First();
            return distance;
        }

    }
}

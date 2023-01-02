using API_mokymai.Models.ApiModels;
using API_mokymai.Services.IServices;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace API_mokymai.Services
{
    public class FakeApiProxyService : IFakeApiProxyService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FakeApiProxyService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<BookApiModel>> GetBooks()
        {
            var baseAddress = new Uri("https://api.openrouteservice.org/geocode/search?api_key=5b3ce3597851110001cf62480dd84b41c6ec48ddaf3924db36366ebb&text=Namibian%20Brewery");

            var httpClient = _httpClientFactory.CreateClient("FakeApi");
            //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json, application/geo+json, application/gpx+xml, img/png; charset=utf-8");
            //httpClient.DefaultRequestHeaders.Add("api_key", "5b3ce3597851110001cf62480dd84b41c6ec48ddaf3924db36366ebb");
            //httpClient.DefaultRequestHeaders.Add("text", "Mazeikiai%20Lietuva");
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "5b3ce3597851110001cf62480dd84b41c6ec48ddaf3924db36366ebb");
            var endpoint = "/geocode/search";
            //var endpoint = "/api/v1/Books";

            var response = await httpClient.GetAsync(baseAddress);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<List<BookApiModel>>(content);
                return res;
            }

            return null;
        }

        //public async Task<IEnumerable<BookApiModel>> GetBooks_AsString()
        //{
        //    var httpClient = _httpClientFactory.CreateClient("FakeApi");
        //    var endpoint = "/api/v1/Books";

        //        var content = await httpClient.GetStringAsync(endpoint);
        //        var res = JsonConvert.DeserializeObject<List<BookApiModel>>(content);
        //        return res;

        //}

        //public async Task<IEnumerable<BookApiModel>> GetBooks_AsJson()
        //{
        //    var httpClient = _httpClientFactory.CreateClient("FakeApi");
        //    var endpoint = "/api/v1/Books";
        //    var res = await httpClient.GetFromJsonAsync<List<BookApiModel>>(endpoint);
        //    return res;

        //}

        //public async Task CreateBook(BookApiModel data)
        //{
        //    var httpClient = _httpClientFactory.CreateClient("FakeApi");
        //    var endpoint = "/api/v1/Books";
        //    var res = await httpClient.PostAsJsonAsync(endpoint, data);

        //}

    }
}

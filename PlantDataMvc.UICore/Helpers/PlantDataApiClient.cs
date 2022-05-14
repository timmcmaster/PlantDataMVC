using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Helpers
{
    public static class NamedHttpClients
    {
        public const string PlantDataApi = "PlantDataApi";
    }

    public interface IPlantDataApiClient
    {
        Task<string> GetProtectedResources();
    }

    public class PlantDataApiClient : IPlantDataApiClient
    {
        private readonly HttpClient _httpClient;

        public PlantDataApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<string> GetProtectedResources()
        {
            // TODO: Fix this
            var response = await _httpClient.GetAsync("/api/protected");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
                throw new Exception("Failed to get protected resources.");
            }
            return await response.Content.ReadAsStringAsync();
        }
    }

}

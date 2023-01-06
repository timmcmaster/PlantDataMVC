using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Common.Client
{

    public class PlantDataApiClient : IPlantDataApiClient
    {
        private readonly HttpClient _httpClient;

        public PlantDataApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        // For now, just wrap httpclient functionality

        public Task<HttpResponseMessage> GetAsync(string uri, CancellationToken cancellationToken) => _httpClient.GetAsync(uri, cancellationToken);
        public Task<HttpResponseMessage> PostAsync(string uri, StringContent content, CancellationToken cancellationToken) => _httpClient.PostAsync(uri, content, cancellationToken);
        public Task<HttpResponseMessage> PutAsync(string uri, StringContent content, CancellationToken cancellationToken) => _httpClient.PutAsync(uri, content, cancellationToken);
        public Task<HttpResponseMessage> DeleteAsync(string uri, CancellationToken cancellationToken) => _httpClient.DeleteAsync(uri, cancellationToken);
    }

}

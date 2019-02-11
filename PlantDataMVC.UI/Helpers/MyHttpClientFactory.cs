using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Net.Http.Headers;
using PlantDataMVC.Constants;

namespace PlantDataMVC.UI.Helpers
{
    public static class NamedHttpClients
    {
        public const string PlantDataApi = "PlantDataApi";
    }

    public interface IMyHttpClientFactory
    {
        HttpClient CreateClient(string client);
    }

    /// <summary>
    /// </summary>
    public class MyHttpClientFactory : IMyHttpClientFactory
    {
        private static readonly ConcurrentDictionary<string, HttpClient> _clients =
            new ConcurrentDictionary<string, HttpClient>();

        private static readonly ConcurrentDictionary<string, Action<HttpClient>> _clientConfigActions =
            new ConcurrentDictionary<string, Action<HttpClient>>();

        public MyHttpClientFactory()
        {
            AddHttpClient(NamedHttpClients.PlantDataApi, client =>
                {
                    client.BaseAddress = new Uri(PlantDataMvcConstants.PlantDataApi);

                    // clear the accept headers and set those we require for ALL client requests
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }
            );
        }

        private void AddHttpClient(string clientName, Action<HttpClient> configureClient)
        {
            _clientConfigActions.TryAdd(clientName, configureClient);
        }

        public HttpClient CreateClient(string clientName)
        {
            HttpClient client = null;

            if (_clients.TryGetValue(clientName, out client))
            {
                return client;
            }

            if (_clientConfigActions.TryGetValue(clientName, out Action<HttpClient> configureClient))
            {
                client = new HttpClient();
                configureClient(client);
                _clients[clientName] = client;
            }

            return client;
        }
    }
}
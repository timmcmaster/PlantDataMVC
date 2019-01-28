using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PlantDataMVC.UI.Helpers
{
    public static class PlantDataApiHttpClient
    {
        private static Func<HttpClient> ValueFactory = () =>
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:53274/");

            // clear the accept headers and set those we require for ALL client requests
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        };

        private static readonly Lazy<HttpClient> _client = new Lazy<HttpClient>(ValueFactory);

        public static HttpClient GetClient()
        {
            return _client.Value;
        }

    }
}
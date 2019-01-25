using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace PlantDataMVC.UI.Helpers
{
    public static class MyHttpClient
    {
        public static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:53274/");

            // clear the accept headers and set those we require for ALL client requests
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
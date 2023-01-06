using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Common.Client
{
    public interface IPlantDataApiClient
    {
        Task<HttpResponseMessage> GetAsync(string uri, CancellationToken cancellationToken);
        Task<HttpResponseMessage> PostAsync(string uri, StringContent content, CancellationToken cancellationToken);
        Task<HttpResponseMessage> PutAsync(string uri, StringContent content, CancellationToken cancellationToken);
        Task<HttpResponseMessage> DeleteAsync(string uri, CancellationToken cancellationToken);
    }

}

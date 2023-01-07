using PlantDataMVC.Common.Client.Models;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Common.Client
{
    public interface IPlantDataApiClient
    {
        Task<ApiResponse<TResponse>> GetAsync<TResponse>(string uri, CancellationToken cancellationToken);

        Task<ApiResponse> PostAsync(string uri, CancellationToken cancellationToken);
        Task<ApiResponse> PostAsync<TRequest>(string uri, TRequest body, CancellationToken cancellationToken);
        Task<ApiResponse<TResponse>> PostAsync<TRequest,TResponse>(string uri, TRequest body, CancellationToken cancellationToken);

        Task<ApiResponse> PutAsync<TRequest>(string uri, TRequest body, CancellationToken cancellationToken);
        Task<ApiResponse<TResponse>> PutAsync<TRequest, TResponse>(string uri, TRequest body, CancellationToken cancellationToken);

        Task<ApiResponse> DeleteAsync(string uri, CancellationToken cancellationToken);
        Task<ApiResponse<TResponse>> DeleteAsync<TResponse>(string uri, CancellationToken cancellationToken);

        Task<ApiResponse> SendAsync(string uri, HttpMethod method, CancellationToken cancellationToken);
        Task<ApiResponse> SendAsync<TRequest>(string uri, HttpMethod method, TRequest body, CancellationToken cancellationToken);
        Task<ApiResponse<TResponse>> SendAsync<TRequest, TResponse>(string uri, HttpMethod method, TRequest body, CancellationToken cancellationToken);

    }

}

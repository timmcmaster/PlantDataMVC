using Newtonsoft.Json;
using PlantDataMVC.Common.Client.Helpers;
using PlantDataMVC.Common.Client.Models;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PlantDataMVC.Common.Client
{

    public class PlantDataApiClient : IPlantDataApiClient
    {
        private readonly HttpClient _httpClient;
        private const string _mediaType = "application/json";

        public PlantDataApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        // For now, just wrap httpclient functionality

        public async Task<ApiResponse<TResponse>> GetAsync<TResponse>(string uri, CancellationToken cancellationToken)
        {
            var result = new ApiResponse<TResponse>();
            var response = await _httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

            if (response != null)
            {
                result.StatusCode = response.StatusCode;
            
                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;

                    result.PagingInfo = HeaderParser.FindAndParsePagingInfo(response.Headers);
                    result.LinkInfo = HeaderParser.FindAndParseLinkInfo(response.Headers);

                    var json = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                    if (TryDeserialiseObject<TResponse>(json, out var content))
                    {
                        result.Content = content;
                    }
                }
            }

            return result;
        }

        public async Task<ApiResponse> PostAsync(string uri, CancellationToken cancellationToken)
        {
            return await SendAsync(uri, HttpMethod.Post, cancellationToken);
        }

        public async Task<ApiResponse> PostAsync<TRequest>(string uri, TRequest body, CancellationToken cancellationToken)
        {
            return await SendAsync(uri, HttpMethod.Post, body, cancellationToken);
        }

        public async Task<ApiResponse<TResponse>> PostAsync<TRequest, TResponse>(string uri, TRequest body, CancellationToken cancellationToken)
        {
            return await SendAsync<TRequest, TResponse>(uri, HttpMethod.Post, body, cancellationToken);
        }

        public async Task<ApiResponse> PutAsync<TRequest>(string uri, TRequest body, CancellationToken cancellationToken)
        {
            return await SendAsync(uri, HttpMethod.Put, body, cancellationToken);
        }

        public async Task<ApiResponse<TResponse>> PutAsync<TRequest, TResponse>(string uri, TRequest body, CancellationToken cancellationToken)
        {
            return await SendAsync<TRequest, TResponse>(uri, HttpMethod.Put, body, cancellationToken);
        }

        public async Task<ApiResponse> DeleteAsync(string uri, CancellationToken cancellationToken)
        {
            var result = new ApiResponse();

            var response = await _httpClient.DeleteAsync(uri, cancellationToken).ConfigureAwait(false);
            if (response != null)
            {
                result.StatusCode = response.StatusCode;
                result.Success = response.IsSuccessStatusCode;
            }

            return result;
        }

        public async Task<ApiResponse<TResponse>> DeleteAsync<TResponse>(string uri, CancellationToken cancellationToken)
        {
            var result = new ApiResponse<TResponse>();

            var response = await _httpClient.DeleteAsync(uri, cancellationToken).ConfigureAwait(false);
            if (response != null)
            {
                result.StatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;

                    var json = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                    if (TryDeserialiseObject<TResponse>(json, out var content))
                    {
                        result.Content = content;
                    }
                }
            }

            return result;
        }

        public async Task<ApiResponse> SendAsync(string uri, HttpMethod method, CancellationToken cancellationToken)
        {
            if (method == null)
                throw new ArgumentNullException(nameof(method));

            if (method == HttpMethod.Get)
            {
                throw new NotSupportedException($"{method.Method} is not supported. Call {nameof(GetAsync)} instead.");
            }

            var result = new ApiResponse();

            using var requestMessage = new HttpRequestMessage(method, uri);

            var response = await _httpClient.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);
            if (response != null)
            {
                result.StatusCode = response.StatusCode;
                result.Success = response.IsSuccessStatusCode;
            }

            return result;
        }

        public async Task<ApiResponse> SendAsync<TRequest>(string uri, HttpMethod method, TRequest body, CancellationToken cancellationToken)
        {
            if (method == null)
                throw new ArgumentNullException(nameof(method));

            if (method == HttpMethod.Get)
            {
                throw new NotSupportedException($"{method.Method} is not supported. Call {nameof(GetAsync)} instead.");
            }

            var result = new ApiResponse();

            using var requestMessage = new HttpRequestMessage(method, uri)
            {
                Content = SerialiseObject(body),
            };

            var response = await _httpClient.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);
            if (response != null)
            {
                result.StatusCode = response.StatusCode;
                result.Success = response.IsSuccessStatusCode;
            }

            return result;
        }

        public async Task<ApiResponse<TResponse>> SendAsync<TRequest, TResponse>(string uri, HttpMethod method, TRequest body, CancellationToken cancellationToken)
        {
            if (method == null)
                throw new ArgumentNullException(nameof(method));

            if (method == HttpMethod.Get)
            {
                throw new NotSupportedException($"{method.Method} is not supported. Call {nameof(GetAsync)} instead.");
            }

            var result = new ApiResponse<TResponse>();

            using var requestMessage = new HttpRequestMessage(method, uri)
            {
                Content = SerialiseObject(body),
            };

            var response = await _httpClient.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);

            if (response != null)
            {
                result.StatusCode = response.StatusCode;
                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;

                    var json = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                    if (TryDeserialiseObject<TResponse>(json, out var content))
                    {
                        result.Content = content;
                    }
                }
            }

            return result;
        }

        private static StringContent SerialiseObject<T>(T instance)
        {
            var json = JsonConvert.SerializeObject(instance);
            return new StringContent(json, new UTF8Encoding(), _mediaType);
        }

        private static bool TryDeserialiseObject<T>(string json, [MaybeNullWhen(false)] out T result)
        {
            if (string.IsNullOrEmpty(json))
            {
                result = default;
                return false;
            }

            result = JsonConvert.DeserializeObject<T>(json);

            if (result == null)
            {
                result = default;
                return false;
            }

            return true;
        }
    }

}

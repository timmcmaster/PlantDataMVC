using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.Extensions.Logging;

namespace PlantDataMVC.Web.Helpers
{
    public interface IIdentityServerClient
    {
        Task<string> RequestClientCredentialsTokenAsync();
        Task<string> RequestRefreshTokenAsync(string refreshToken);
    }

    public class IdentityServerClient : IIdentityServerClient
    {
        private readonly HttpClient _httpClient;
        private readonly ClientCredentialsTokenRequest _tokenRequest;
        private readonly RefreshTokenRequest _refreshTokenRequest;
        private readonly ILogger<IdentityServerClient> _logger;

        public IdentityServerClient(HttpClient httpClient, 
            ClientCredentialsTokenRequest tokenRequest, 
            //RefreshTokenRequest refreshTokenRequest,
            ILogger<IdentityServerClient> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _tokenRequest = tokenRequest ?? throw new ArgumentNullException(nameof(tokenRequest));
            //_refreshTokenRequest = refreshTokenRequest ?? throw new ArgumentNullException(nameof(refreshTokenRequest));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<string> RequestClientCredentialsTokenAsync()
        {
            // as a first draft, just get the discovery doc every time
            // want to either cache or store this locally
            var disco = await _httpClient.GetDiscoveryDocumentAsync();
            if (disco.IsError)
            {
                _logger.LogError(disco.Error);
                throw new HttpRequestException("Something went wrong while retrieving discovery document");
            }

            _tokenRequest.Address = disco.TokenEndpoint;

            // request the access token
            var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(_tokenRequest);
            if (tokenResponse.IsError)
            {
                _logger.LogError(tokenResponse.Error);
                throw new HttpRequestException("Something went wrong while requesting the access token");
            }
            return tokenResponse.AccessToken;
        }

        public async Task<string> RequestRefreshTokenAsync(string refreshToken)
        {
            //// request the access token
            //_refreshTokenRequest.RefreshToken = refreshToken;   

            //var tokenResponse = await _httpClient.RequestRefreshTokenAsync(_refreshTokenRequest);
            //if (tokenResponse.IsError)
            //{
            //    _logger.LogError(tokenResponse.Error);
            //    throw new HttpRequestException("Something went wrong while requesting the refresh token");
            //}
            //return tokenResponse.AccessToken;
            return "";
        }
    }
}

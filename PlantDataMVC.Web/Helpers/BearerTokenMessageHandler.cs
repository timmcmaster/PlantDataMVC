using IdentityModel.Client;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Helpers
{
    public class BearerTokenMessageHandler : DelegatingHandler
    {
        private readonly IIdentityServerClient _identityServerClient;

        public BearerTokenMessageHandler(IIdentityServerClient identityServerClient)
        {
            _identityServerClient = identityServerClient;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var accessToken = await _identityServerClient.RequestClientCredentialsTokenAsync();
            if (accessToken != null)
            {
                request.SetBearerToken(accessToken);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
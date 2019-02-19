using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace PlantDataMVC.UI.Helpers
{
    public class TokenMessageHandler: DelegatingHandler
    {
        public TokenMessageHandler()
        {
            this.InnerHandler = new HttpClientHandler();
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                               CancellationToken cancellationToken)
        {
            var token = (HttpContext.Current.User.Identity as ClaimsIdentity).FindFirst("access_token");

            if (token.Value != null)
            {
                request.SetBearerToken(token.Value);
            }

            return base.SendAsync(request,cancellationToken);
        }
    }
}
using System.Web;

namespace PlantDataMVC.Tests.UI.TestDoubles
{
    internal class StubContext : HttpContextBase
    {
        private readonly StubRequest request;

        public StubContext(string relativeUrl)
        {
            request = new StubRequest(relativeUrl);
        }

        public override HttpRequestBase Request
        {
            get => request;
        }
    }
}
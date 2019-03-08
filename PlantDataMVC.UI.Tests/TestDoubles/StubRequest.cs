using System.Web;

namespace PlantDataMVC.UI.Tests.TestDoubles
{
    public class StubRequest : HttpRequestBase
    {
        public StubRequest(string relativeUrl)
        {
            AppRelativeCurrentExecutionFilePath = relativeUrl;
        }

        public override string AppRelativeCurrentExecutionFilePath { get; }

        public override string PathInfo
        {
            get => "";
        }
    }
}
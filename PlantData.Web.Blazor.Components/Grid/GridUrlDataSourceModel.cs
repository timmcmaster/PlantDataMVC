using PlantDataMVC.Constants;

namespace PlantData.Web.Blazor.SharedComponents.Grid
{
    public class GridUrlDataSourceModel
    {
        public GridUrlDataSourceModel(string controllerName)
        {         
            BaseUrl = GetBaseUrl(controllerName);
        }

        public string BaseUrl { get; internal set; }
        public string Url => $"{BaseUrl}";
        public string InsertUrl => $"{BaseUrl}/Insert";
        public string UpdateUrl => $"{BaseUrl}/Update";
        public string DeleteUrl => $"{BaseUrl}/Delete";

        private static string GetBaseUrl(string controllerName) => PlantDataMvcConstants.PlantDataBlazorClient + "/data/" + controllerName;

        public static string GetUrl(string controllerName, string methodName)
        {
            string baseUrl = GetBaseUrl(controllerName);

            return $"{baseUrl}/{methodName}";
        }
    }
}

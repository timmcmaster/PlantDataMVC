using PlantDataMVC.Constants;

namespace PlantData.Web.Blazor.SharedComponents.Grid
{
    public class GridUrlDataSourceModel
    {
        public GridUrlDataSourceModel(string controllerName)
        {         
            BaseUrl = PlantDataMvcConstants.PlantDataBlazorClient + "/data/" + controllerName;
        }

        public string BaseUrl { get; internal set; }
        public string Url => $"{BaseUrl}";
        public string InsertUrl => $"{BaseUrl}/Insert";
        public string UpdateUrl => $"{BaseUrl}/Update";
        public string DeleteUrl => $"{BaseUrl}/Delete";
    }
}

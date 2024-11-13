namespace PlantData.Web.Blazor.SharedComponents.Grid
{
    public class GridLinksModel
    {
        public GridLinksModel(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        public string BaseUrl { get; internal set; }
        public string AddNew => $"{BaseUrl}/new";
        public string Show => $"{BaseUrl}";
        public string Edit => $"{BaseUrl}/edit";
        public string Delete => $"{BaseUrl}/delete";
    }
}

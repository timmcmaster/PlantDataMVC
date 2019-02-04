using Framework.Web.Forms;

namespace PlantDataMVC.UI.Models.EditModels
{
    public class SiteCreateEditModel : IForm<bool>
    {
        public string SiteName { get; set; }
        public string Suburb { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}

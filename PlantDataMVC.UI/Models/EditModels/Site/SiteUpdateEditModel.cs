using Framework.Web.Forms;

namespace PlantDataMVC.UI.Models.EditModels.Site
{
    public class SiteUpdateEditModel : IForm<bool>
    {
        public int Id { get; set; }
        public string SiteName { get; set; }
        public string Suburb { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}

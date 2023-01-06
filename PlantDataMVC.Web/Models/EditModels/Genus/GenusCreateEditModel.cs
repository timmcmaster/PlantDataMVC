using Framework.Web.Forms;

namespace PlantDataMVC.Web.Models.EditModels.Genus
{
    public class GenusCreateEditModel : IForm<bool>
    {
        public string LatinName { get; set; }
    }
}
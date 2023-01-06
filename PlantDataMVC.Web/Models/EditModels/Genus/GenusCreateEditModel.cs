using Framework.Web.Forms;

namespace PlantDataMVC.UICore.Models.EditModels.Genus
{
    public class GenusCreateEditModel : IForm<bool>
    {
        public string LatinName { get; set; }
    }
}
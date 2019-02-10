using Framework.Web.Forms;

namespace PlantDataMVC.UI.Models.EditModels.Genus
{
    public class GenusCreateEditModel: IForm<bool>
    {
        public string LatinName { get; set; }
    }
}
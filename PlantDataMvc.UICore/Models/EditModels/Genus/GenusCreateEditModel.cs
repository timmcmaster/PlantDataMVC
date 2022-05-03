using Framework.Web.Core.Forms;

namespace PlantDataMVC.UICore.Models.EditModels.Genus
{
    public class GenusCreateEditModel : IForm<bool>
    {
        public string LatinName { get; set; }
    }
}
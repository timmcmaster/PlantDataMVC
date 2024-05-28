using Framework.Web.Forms;

namespace PlantData.Web.Mvc.Models.EditModels.Genus
{
    public class GenusCreateEditModel : IForm<bool>
    {
        public string LatinName { get; set; }
    }
}
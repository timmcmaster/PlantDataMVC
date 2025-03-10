using Framework.Web.Forms;

namespace PlantData.Web.Blazor.UIModels.EditModels.Genus
{
    public class GenusCreateEditModel : IForm<bool>
    {
        public string LatinName { get; set; }
    }
}
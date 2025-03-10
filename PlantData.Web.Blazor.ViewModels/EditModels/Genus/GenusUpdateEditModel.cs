using Framework.Web.Forms;

namespace PlantData.Web.Blazor.UIModels.EditModels.Genus
{
    public class GenusUpdateEditModel : IForm<bool>
    {
        public int Id { get; set; }
        public string LatinName { get; set; }
    }
}
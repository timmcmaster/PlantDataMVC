using Framework.Web.Core.Forms;

namespace PlantDataMVC.UICore.Models.EditModels.Genus
{
    public class GenusUpdateEditModel : IForm<bool>
    {
        public int Id { get; set; }
        public string LatinName { get; set; }
    }
}
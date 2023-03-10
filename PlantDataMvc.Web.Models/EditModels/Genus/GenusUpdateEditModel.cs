using Framework.Web.Forms;

namespace PlantDataMVC.Web.Models.EditModels.Genus
{
    public class GenusUpdateEditModel : IForm<bool>
    {
        public int Id { get; set; }
        public string LatinName { get; set; }
    }
}
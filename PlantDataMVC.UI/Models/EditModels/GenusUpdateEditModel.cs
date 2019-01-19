using Framework.Web.Forms;

namespace PlantDataMVC.UI.Models.EditModels
{
    public class GenusUpdateEditModel : IForm
    {
        public int Id { get; set; }
        public string LatinName { get; set; }
    }
}
using Framework.Web.Forms;

namespace PlantData.Web.Mvc.Models.EditModels.Genus
{
    public class GenusUpdateEditModel : IForm<bool>
    {
        public int Id { get; set; }
        public string LatinName { get; set; }
    }
}
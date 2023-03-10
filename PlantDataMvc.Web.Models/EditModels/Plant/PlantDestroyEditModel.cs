using Framework.Web.Forms;

namespace PlantDataMVC.Web.Models.EditModels.Plant

{
    public class PlantDestroyEditModel : IForm<bool>
    {
        public int Id { get; set; }
    }
}
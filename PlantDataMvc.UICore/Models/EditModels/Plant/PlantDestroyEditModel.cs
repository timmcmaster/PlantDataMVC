using Framework.Web.Core.Forms;

namespace PlantDataMVC.UICore.Models.EditModels.Plant

{
    public class PlantDestroyEditModel : IForm<bool>
    {
        public int Id { get; set; }
    }
}
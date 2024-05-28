using Framework.Web.Forms;

namespace PlantData.Web.Mvc.Models.EditModels.Plant

{
    public class PlantDestroyEditModel : IForm<bool>
    {
        public int Id { get; set; }
    }
}
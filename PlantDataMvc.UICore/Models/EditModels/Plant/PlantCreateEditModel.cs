using Framework.Web.Core.Forms;

namespace PlantDataMVC.UICore.Models.EditModels.Plant
{
    public class PlantCreateEditModel : IForm<bool>
    {
        public int GenusId { get; set; }
        public string Species { get; set; }
        public string CommonName { get; set; }
        public string Description { get; set; }
        public int PropagationTime { get; set; }
        public bool Native { get; set; }
    }
}
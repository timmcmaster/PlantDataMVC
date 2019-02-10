using System.Web.Mvc;
using Framework.Web.Forms;
using PlantDataMVC.UI.ModelBinders;

namespace PlantDataMVC.UI.Models.EditModels.Plant
{
    // HACK: So that we can debug binding for this model
    [ModelBinder(typeof(DebugModelBinder))]
    public class PlantCreateEditModel : IForm<bool>
    {
        public string Genus { get; set; }
        public string Species { get; set; }
        public string CommonName { get; set; }
        public string Description { get; set; }
        public int PropagationTime { get; set; }
        public bool Native { get; set; }
    }
}
using Framework.Web.Forms;
using PlantDataMVC.UI.ModelBinders;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Models
{
    // HACK: So that we can debug binding for this model
    [ModelBinder(typeof(DebugModelBinder))]
    public class PlantCreateEditModel : IForm
    {
        public string Genus { get; set; }
        public string Species { get; set; }
        public string CommonName { get; set; }
        public string Description { get; set; }
        public int PropagationTime { get; set; }
        public bool Native { get; set; }
    }
}
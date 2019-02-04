using Framework.Web.Forms;
using PlantDataMVC.UI.ModelBinders;
using System;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Models.EditModels
{
    // HACK: So that we can debug binding for this model
    [ModelBinder(typeof(DebugModelBinder))]
    public class PlantSeedCreateEditModel : IForm<bool>
    {
        public int SpeciesId { get; set; }
        public DateTime DateCollected { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public int? SiteId { get; set; }
    }
}

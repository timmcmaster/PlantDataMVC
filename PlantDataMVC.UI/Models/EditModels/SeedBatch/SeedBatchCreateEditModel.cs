using System;
using System.Web.Mvc;
using Framework.Web.Forms;
using PlantDataMVC.UI.ModelBinders;

namespace PlantDataMVC.UI.Models.EditModels.SeedBatch
{
    // HACK: So that we can debug binding for this model
    [ModelBinder(typeof(DebugModelBinder))]
    public class SeedBatchCreateEditModel : IForm<bool>
    {
        public int SpeciesId { get; set; }
        public DateTime DateCollected { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public int? SiteId { get; set; }
    }
}

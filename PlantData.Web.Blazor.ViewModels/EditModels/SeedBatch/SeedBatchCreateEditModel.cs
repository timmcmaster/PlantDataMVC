using Framework.Web.Forms;
using System;

namespace PlantData.Web.Blazor.UIModels.EditModels.SeedBatch
{
    public class SeedBatchCreateEditModel : IForm<bool>
    {
        public int SpeciesId { get; set; }
        public DateTime DateCollected { get; set; }
        public string? Location { get; set; }
        public string? Notes { get; set; }
        public int SiteId { get; set; }
    }
}

using System;
using Framework.Web.Core.Forms;

namespace PlantDataMVC.UICore.Models.EditModels.SeedTray
{
    public class SeedTrayCreateEditModel : IForm<bool>
    {
        public int SeedBatchId { get; set; }
        public DateTime DatePlanted { get; set; }
        public string? Treatment { get; set; }
        public bool ThrownOut { get; set; }
    }
}

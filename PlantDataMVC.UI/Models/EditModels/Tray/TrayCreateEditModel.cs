using System;
using Framework.Web.Forms;

namespace PlantDataMVC.UI.Models.EditModels.Tray
{
    public class TrayCreateEditModel : IForm<bool>
    {
        public int SeedBatchId { get; set; }
        public DateTime DatePlanted { get; set; }
        public string Treatment { get; set; }
        public bool ThrownOut { get; set; }
    }
}

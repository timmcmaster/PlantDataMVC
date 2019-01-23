using Framework.Web.Forms;
using System;

namespace PlantDataMVC.UI.Models.EditModels
{
    public class TrayCreateEditModel : IForm
    {
        public int SeedBatchId { get; set; }
        public DateTime DatePlanted { get; set; }
        public string Treatment { get; set; }
        public bool ThrownOut { get; set; }
    }
}

using System;
using Framework.Web.Forms;

namespace PlantDataMVC.Web.Models.EditModels.SeedTray
{
    public class SeedTrayCreateEditModel : IForm<bool>
    {
        public int SeedBatchId { get; set; }
        public DateTime DateSown { get; set; }
        public string? Treatment { get; set; }
        public bool ThrownOut { get; set; }
    }
}

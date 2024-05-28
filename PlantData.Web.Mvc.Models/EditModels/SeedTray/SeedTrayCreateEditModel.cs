using System;
using Framework.Web.Forms;

namespace PlantData.Web.Mvc.Models.EditModels.SeedTray
{
    public class SeedTrayCreateEditModel : IForm<bool>
    {
        public int SeedBatchId { get; set; }
        public DateTime DateSown { get; set; }
        public string? Treatment { get; set; }
        public bool ThrownOut { get; set; }
    }
}

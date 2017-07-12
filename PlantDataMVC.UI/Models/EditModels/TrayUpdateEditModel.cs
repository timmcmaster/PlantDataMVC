using PlantDataMVC.UI.Forms;
using System;

namespace PlantDataMVC.UI.Models
{
    public class TrayUpdateEditModel : IForm
    {
        public int Id { get; set; }
        public int SeedBatchId { get; set; }
        public DateTime DatePlanted { get; set; }
        public string Treatment { get; set; }
        public bool ThrownOut { get; set; }
    }
}

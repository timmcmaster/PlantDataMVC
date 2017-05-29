using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMVC.UI.Models
{
    public class TrayCreateEditModel
    {
        public int SeedBatchId { get; set; }
        public DateTime DatePlanted { get; set; }
        public string Treatment { get; set; }
        public bool ThrownOut { get; set; }
    }
}

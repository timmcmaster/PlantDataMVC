using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMVC.UI.Models
{
    public class PlantSeedUpdateEditModel
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }
        public DateTime DateCollected { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
    }
}

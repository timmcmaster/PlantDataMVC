using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.DAL.Interfaces;

namespace PlantDataMVC.DAL.Entities
{
    /// <summary>
    /// This class is the class for xxxx objects passed outside the DAL.
    /// Other implementations are mapped to an object of this type.
    /// </summary>
    public class SeedBatch : ISeedBatch
    {
        public SeedBatch()
        {
            SeedTrays = new List<SeedTray>();
        }

        public int Id { get; set; }
        public int SpeciesId { get; set; }
        public string SpeciesLatinName { get; set; }
        public string SpeciesCommonName { get; set; }
        public DateTime DateCollected { get; set; }
        public int SiteId { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }

        public virtual Species Species { get; set; }
        public virtual IList<SeedTray> SeedTrays { get; set; }
        public virtual Site Site { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.DAL.Interfaces;

namespace PlantDataMVC.DAL.Entities
{
    /// <summary>
    /// This class is the class for Species objects passed outside the DAL.
    /// Other implementations are mapped to an object of this type.
    /// </summary>
    public class Species : ISpecies
    {
        public Species()
        {
            PlantStocks = new List<PlantStock>();
            SeedBatches = new List<SeedBatch>();
        }

        public int Id { get; set; }
        public int GenusId { get; set; }
        public string GenusLatinName { get; set; }
        public string LatinName { get; set; }
        public string CommonName { get; set; }
        public string Description { get; set; }
        public Nullable<int> PropagationTime { get; set; }
        public bool Native { get; set; }

        public IList<PlantStock> PlantStocks { get; set; }
        public IList<SeedBatch> SeedBatches { get; set; }
    }
}

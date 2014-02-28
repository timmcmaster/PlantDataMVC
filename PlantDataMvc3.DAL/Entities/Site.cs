using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMvc3.DAL.Interfaces;

namespace PlantDataMvc3.DAL.Entities
{
    /// <summary>
    /// This class is the class for Site objects passed outside the DAL.
    /// Other implementations are mapped to an object of this type.
    /// </summary>
    public class Site : ISite
    {
        public Site()
        {
            SeedBatches = new List<SeedBatch>();
        }

        public int Id { get; set; }
        public string SiteName { get; set; }
        public string Suburb { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public virtual IList<SeedBatch> SeedBatches { get; set; }
    }
}

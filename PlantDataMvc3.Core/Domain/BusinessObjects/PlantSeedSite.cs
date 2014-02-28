using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMvc3.Core.Domain.BusinessObjects
{
    public class PlantSeedSite: DomainEntity
    {
        private List<PlantSeed> _seedBatches;

        public string SiteName { get; set; }
        public string Suburb { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public PlantSeed[] SeedBatches
        {
            get
            {
                return _seedBatches.ToArray();
            }
            set
            {
                _seedBatches = new List<PlantSeed>(value);
            }
        }

        public PlantSeedSite()
            : this(0, "", "", 0, 0, new PlantSeed[] {})
        {
        }

        public PlantSeedSite(int id, string siteName, string suburb, decimal latitude, decimal longitude, PlantSeed[] seedBatches)
        {
            this.Id = id;
            this.SiteName = siteName;
            this.Suburb = suburb;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.SeedBatches = seedBatches;
        }
    }
}

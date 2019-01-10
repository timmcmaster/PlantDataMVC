using System;
using System.Collections.Generic;

namespace PlantDataMVC.Domain.Entities
{
    public class PlantSeedSite: DtoEntity
    {
        //private List<PlantSeed> _seedBatches;

        public string SiteName { get; set; }
        public string Suburb { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public override string DisplayValue { get { return this.SiteName; } }

        //public PlantSeed[] SeedBatches
        //{
        //    get
        //    {
        //        return _seedBatches.ToArray();
        //    }
        //    set
        //    {
        //        _seedBatches = new List<PlantSeed>(value);
        //    }
        //}

        public PlantSeedSite()
        {
        }

        //public PlantSeedSite()
        //    : this(0, "", "", 0, 0)
        //{
        //}

        //public PlantSeedSite(int id, string siteName, string suburb, decimal latitude, decimal longitude)
        //{
        //    this.Id = id;
        //    this.SiteName = siteName;
        //    this.Suburb = suburb;
        //    this.Latitude = latitude;
        //    this.Longitude = longitude;
        //    //this.SeedBatches = seedBatches;
        //}
    }
}

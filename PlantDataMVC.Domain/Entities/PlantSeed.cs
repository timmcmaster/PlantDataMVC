using System;
using System.Collections.Generic;

namespace PlantDataMVC.Domain.Entities
{
    public class PlantSeed: DomainEntity
    {
        //private List<PlantSeedTray> _seedTrays;

        public int SpeciesId { get; set; }
        public string SpeciesBinomial { get; set; }
        public DateTime DateCollected { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }

        public override string DisplayValue
        {
            get
            {
                //return this.Id.ToString(); 
                return String.Format("{0},{1:d}", this.SpeciesBinomial, this.DateCollected);
            }
        }

        //public PlantSeedTray[] SeedTrays
        //{
        //    get
        //    {
        //        return _seedTrays.ToArray();
        //    }
        //    set
        //    {
        //        _seedTrays = new List<PlantSeedTray>(value);
        //    }
        //}

        public PlantSeed()
        {
            this.DateCollected = new DateTime();
        }

        //public PlantSeed()
        //    : this(0, 0, "", new DateTime(), "", "")
        //{
        //}

        //public PlantSeed(int id, int speciesId, string speciesBinomial, DateTime dateCollected, string location, string notes)
        //{
        //    this.Id = id;
        //    this.SpeciesId = speciesId;
        //    this.SpeciesBinomial = speciesBinomial;
        //    this.DateCollected = dateCollected;
        //    this.Location = location;
        //    this.Notes = notes;
        //}
    }
}

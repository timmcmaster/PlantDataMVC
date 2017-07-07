using System;
using System.Collections.Generic;

namespace PlantDataMVC.Domain.Entities
{
    public class PlantSeed: DomainEntity
    {
        private List<PlantSeedTray> _seedTrays;

        public int SpeciesId { get; set; }
        public string SpeciesBinomial { get; set; }
        public DateTime DateCollected { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }

        public PlantSeedTray[] SeedTrays
        {
            get
            {
                return _seedTrays.ToArray();
            }
            set
            {
                _seedTrays = new List<PlantSeedTray>(value);
            }
        }

        public PlantSeed()
            : this(0, 0, DateTime.Today, "", "", new PlantSeedTray[] {})
        {
        }

        public PlantSeed(int id, int speciesId, DateTime dateCollected, string location, string notes, PlantSeedTray[] seedTrays)
        {
            this.Id = id;
            this.SpeciesId = speciesId;
            this.DateCollected = dateCollected;
            this.Location = location;
            this.Notes = notes;
            this.SeedTrays = seedTrays;
        }
    }
}

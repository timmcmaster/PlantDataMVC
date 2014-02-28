using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PlantDataMvc3.Core.Domain.BusinessObjects
{
    public class Plant: DomainEntity
    {
        private List<PlantSeed> _seeds;
        private List<PlantStockEntry> _stock;

        public string LatinName
        {
            get { return Plant.FormatName(GenusLatinName, SpeciesLatinName); }
        }
        public string GenusLatinName { get; set; }
        public string SpeciesLatinName { get; set; }
        public string CommonName { get; set; }
        public string Description { get; set; }
        public bool Native { get; set; }
        public int PropagationTime { get; set; }

        public PlantSeed[] Seeds 
        {
            get
            {
                return _seeds.ToArray();
            }
            set
            {
                _seeds = new List<PlantSeed>(value);
            }
        }

        public PlantStockEntry[] Stock
        {
            get
            {
                return _stock.ToArray();
            }
            set
            {
                _stock = new List<PlantStockEntry>(value);
            }
        }

        public Plant()
            : this(0, "", "", "", "", true, 0, new PlantSeed[] { }, new PlantStockEntry[] { })
        {
        }

        //public Plant(int id, string latinName, string commonName, string description, bool native, int propagationTime, PlantSeed[] seeds, PlantStockEntry[] stock)
        public Plant(int id, string genusLatinName, string speciesLatinName, string commonName, string description, bool native, int propagationTime, PlantSeed[] seeds, PlantStockEntry[] stock)
        {
            this.Id = id;
            //this.LatinName = latinName;
            this.GenusLatinName = genusLatinName;
            this.SpeciesLatinName = speciesLatinName;
            this.CommonName = commonName;
            this.Description = description;
            this.Native = native;
            this.PropagationTime = propagationTime;
            this.Seeds = seeds;
            this.Stock = stock;
        }

        public static string FormatName(string genus, string species)
        {
            if ((genus == null) && (species == null))
                return "";
            else if (genus == null)
                return species;
            else if (species == null)
                return genus;
            else
                return String.Format("{0} {1}", genus.Trim(), species.Trim());
        }
    }
}

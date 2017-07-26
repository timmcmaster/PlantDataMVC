using System;
using System.Collections.Generic;

namespace PlantDataMVC.Domain.Entities
{
    public class Plant : DomainEntity
    {
        //private List<PlantSeed> _seeds;
        //private List<PlantStockEntry> _stock;

        //public string LatinName
        //{
        //    get { return SpeciesBinomial; }
        //}
        public string GenericName { get; set; }
        public string SpecificName { get; set; }
        public string Binomial { get; set; }
        public string CommonName { get; set; }
        public string Description { get; set; }
        public bool Native { get; set; }
        public int PropagationTime { get; set; }

        public override string DisplayValue { get { return this.Binomial; } }

        //public PlantSeed[] Seeds 
        //{
        //    get
        //    {
        //        return _seeds.ToArray();
        //    }
        //    set
        //    {
        //        _seeds = new List<PlantSeed>(value);
        //    }
        //}

        //public PlantStockEntry[] Stock
        //{
        //    get
        //    {
        //        return _stock.ToArray();
        //    }
        //    set
        //    {
        //        _stock = new List<PlantStockEntry>(value);
        //    }
        //}

        // Default constructor
        public Plant()
        {
        }

        //public Plant()
        //    : this(0, "", "", "", "", true, 0)
        //{
        //}

        //public Plant(int id, string genericName, string specificName, string commonName, string description, bool native, int propagationTime)
        //{
        //    this.Id = id;
        //    //this.LatinName = latinName;
        //    this.GenericName = genericName;
        //    this.SpecificName = specificName;
        //    this.CommonName = commonName;
        //    this.Description = description;
        //    this.Native = native;
        //    this.PropagationTime = propagationTime;
        //    //this.Seeds = seeds;
        //    //this.Stock = stock;
        //}

        //public static string FormatName(string genus, string species)
        //{
        //    if ((genus == null) && (species == null))
        //        return "";
        //    else if (genus == null)
        //        return species;
        //    else if (species == null)
        //        return genus;
        //    else
        //        return String.Format("{0} {1}", genus.Trim(), species.Trim());
        //}
    }
}

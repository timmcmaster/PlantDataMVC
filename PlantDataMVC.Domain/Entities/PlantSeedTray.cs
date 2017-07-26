using System;
using System.Collections.Generic;

namespace PlantDataMVC.Domain.Entities
{
    public class PlantSeedTray: DomainEntity
    {
        //private List<PlantStockTransaction> _plantStockTransactions;

        public int SeedBatchId { get; set; }
        public DateTime DatePlanted { get; set; }
        public string Treatment { get; set; }
        public bool ThrownOut { get; set; }

        public override string DisplayValue { get { return this.Id.ToString(); } }

        //public PlantStockTransaction[] PlantStockTransactions
        //{
        //    get
        //    {
        //        return _plantStockTransactions.ToArray();
        //    }
        //    set
        //    {
        //        _plantStockTransactions = new List<PlantStockTransaction>(value);
        //    }
        //}

        public PlantSeedTray()
        {
            this.DatePlanted = new DateTime();
        }

        //public PlantSeedTray()
        //    : this(0, 0, new DateTime(), "", false)
        //{
        //}

        //public PlantSeedTray(int id, int seedBatchId, DateTime datePlanted, string treatment, bool thrownOut)
        //{
        //    this.Id = id;
        //    this.SeedBatchId = seedBatchId;
        //    this.DatePlanted = datePlanted;
        //    this.Treatment = treatment;
        //    this.ThrownOut = thrownOut;
        //    //this.PlantStockTransactions = plantStockTransactions;
        //}
    }
}

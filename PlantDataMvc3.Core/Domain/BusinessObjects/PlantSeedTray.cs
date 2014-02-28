using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMvc3.Core.Domain.BusinessObjects
{
    public class PlantSeedTray: DomainEntity
    {
        private List<PlantStockTransaction> _plantStockTransactions;

        public int SeedBatchId { get; set; }
        public DateTime DatePlanted { get; set; }
        public string Treatment { get; set; }
        public bool ThrownOut { get; set; }

        public PlantStockTransaction[] PlantStockTransactions
        {
            get
            {
                return _plantStockTransactions.ToArray();
            }
            set
            {
                _plantStockTransactions = new List<PlantStockTransaction>(value);
            }
        }

        public PlantSeedTray()
            : this(0, 0, DateTime.Today, "", false, new PlantStockTransaction[] { })
        {
        }

        public PlantSeedTray(int id, int seedBatchId, DateTime datePlanted, string treatment, bool thrownOut, PlantStockTransaction[] plantStockTransactions)
        {
            this.Id = id;
            this.SeedBatchId = seedBatchId;
            this.DatePlanted = datePlanted;
            this.Treatment = treatment;
            this.ThrownOut = thrownOut;
            this.PlantStockTransactions = plantStockTransactions;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMvc3.Core.Domain.BusinessObjects
{
    public class PlantStockTransaction: DomainEntity
    {
        public int PlantStockEntryId { get; set; }
        public PlantStockTransactionType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Quantity { get; set; }
        public int SeedTrayId { get; set; }
        public string TransactionSource { get; set; }
        public string Notes { get; set; }

        public PlantStockTransaction()
            : this(0, 0, new PlantStockTransactionType(), DateTime.Today, 0, 0, "", "")
        {
        }

        public PlantStockTransaction(int id, int plantStockEntryId, PlantStockTransactionType transactionType, DateTime transactionDate, int quantity, int seedTrayId, string transactionSource, string notes)
        {
            this.Id = id;
            this.PlantStockEntryId = plantStockEntryId;
            this.TransactionType = transactionType;
            this.TransactionDate = transactionDate;
            this.Quantity = quantity;
            this.SeedTrayId = seedTrayId;
            this.TransactionSource = transactionSource;
            this.Notes = notes;
        }
    }
}

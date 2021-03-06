﻿using System;

namespace PlantDataMVC.Domain.Entities
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

        public override string DisplayValue { get { return this.Id.ToString(); } }

        public PlantStockTransaction()
        {
            this.TransactionType = new PlantStockTransactionType();
            this.TransactionDate = new DateTime();
        }

        //public PlantStockTransaction()
        //    : this(0, 0, new PlantStockTransactionType(), new DateTime(), 0, 0, "", "")
        //{
        //}

        //public PlantStockTransaction(int id, int plantStockEntryId, PlantStockTransactionType transactionType, DateTime transactionDate, int quantity, int seedTrayId, string transactionSource, string notes)
        //{
        //    this.Id = id;
        //    this.PlantStockEntryId = plantStockEntryId;
        //    this.TransactionType = transactionType;
        //    this.TransactionDate = transactionDate;
        //    this.Quantity = quantity;
        //    this.SeedTrayId = seedTrayId;
        //    this.TransactionSource = transactionSource;
        //    this.Notes = notes;
        //}
    }
}

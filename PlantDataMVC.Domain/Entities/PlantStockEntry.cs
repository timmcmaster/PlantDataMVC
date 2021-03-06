﻿using System.Collections.Generic;

namespace PlantDataMVC.Domain.Entities
{
    public class PlantStockEntry: DomainEntity
    {
        //private List<PlantStockTransaction> _transactions;

        public int SpeciesId { get; set; }
        public string SpeciesBinomial { get; set; }
        public PlantProductType ProductType { get; set; }
        public int QuantityInStock { get; set; }

        public override string DisplayValue { get { return this.Id.ToString(); } }

        //public PlantStockTransaction[] Transactions
        //{
        //    get
        //    {
        //        return _transactions.ToArray();
        //    }
        //    set
        //    {
        //        _transactions = new List<PlantStockTransaction>(value);
        //    }
        //}


        public PlantStockEntry()
        {
            this.ProductType = new PlantProductType();
        }

        //public PlantStockEntry()
        //    : this(0, 0, new PlantProductType(), 0)
        //{
        //}

        //public PlantStockEntry(int id, int speciesId, PlantProductType productType, int quantityInStock)
        //{
        //    this.Id = id;
        //    this.SpeciesId = speciesId;
        //    this.ProductType = productType;
        //    this.QuantityInStock = quantityInStock;
        //    //this.Transactions = transactions;
        //}
    }
}

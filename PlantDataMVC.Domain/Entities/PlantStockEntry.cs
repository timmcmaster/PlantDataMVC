using System.Collections.Generic;

namespace PlantDataMVC.Domain.Entities
{
    public class PlantStockEntry: DomainEntity
    {
        private List<PlantStockTransaction> _transactions;

        public int SpeciesId { get; set; }
        public PlantProductType ProductType { get; set; }
        public int QuantityInStock { get; set; }

        public PlantStockTransaction[] Transactions
        {
            get
            {
                return _transactions.ToArray();
            }
            set
            {
                _transactions = new List<PlantStockTransaction>(value);
            }
        }


        public PlantStockEntry()
            : this(0, 0, new PlantProductType() { Id = 0, Name = "" }, 0, new PlantStockTransaction[] { })
        {
        }

        public PlantStockEntry(int id, int speciesId, PlantProductType productType, int quantityInStock, PlantStockTransaction[] transactions)
        {
            this.Id = id;
            this.SpeciesId = speciesId;
            this.ProductType = productType;
            this.QuantityInStock = quantityInStock;
            this.Transactions = transactions;
        }
    }
}

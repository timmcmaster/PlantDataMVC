using System;

namespace PlantDataMVC.Domain.Entities
{
    public class PlantProductPrice
    {
        public PlantProductType ProductType { get; set; }
        public PlantPriceListType PriceListType{ get; set; }
        public DateTime DateEffective { get; set; }
        public decimal Price { get; set; }

        public PlantProductPrice() : this(new PlantProductType(), new PlantPriceListType(), new DateTime(), 0)
        {
        }

        public PlantProductPrice(PlantProductType productType, PlantPriceListType plantPriceListType, DateTime dateEffective, decimal price)
        {
            this.ProductType = productType;
            this.PriceListType = PriceListType;
            this.DateEffective = dateEffective;
            this.Price = price;
        }
    }
}

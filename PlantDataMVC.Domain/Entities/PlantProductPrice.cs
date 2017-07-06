using System;

namespace PlantDataMVC.Domain.Entities
{
    public class PlantProductPrice
    {
        public PlantProductType ProductType { get; set; }
        public PlantPriceListType PriceListType{ get; set; }
        public DateTime DateEffective { get; set; }
        public decimal Price { get; set; }

        public PlantProductPrice(): this(new PlantProductType(){ Id=0, Name="" }, new PlantPriceListType(){ Id=0, Name="", Kind="R" } ,DateTime.Today, (decimal)0.00)
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

using System;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class ProductPriceDataModel : IDataModel
    {
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public int PriceListTypeId { get; set; }
        public string PriceListTypeName { get; set; }
        public DateTime DateEffective { get; set; }
        public decimal Price { get; set; }
        public string BarcodeSKU { get; set; }
    }
}
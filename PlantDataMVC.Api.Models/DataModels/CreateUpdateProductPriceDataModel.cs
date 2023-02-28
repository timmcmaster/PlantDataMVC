using System;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class CreateUpdateProductPriceDataModel : IDataModel
    {
        public int ProductTypeId { get; set; }
        public int PriceListTypeId { get; set; }
        public DateTime DateEffective { get; set; }
        public decimal Price { get; set; }
    }
}
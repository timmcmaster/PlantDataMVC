using PlantDataMVC.Api.Models;
using System;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class ProductPriceDataModel : IDto
    {
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public int PriceListTypeId { get; set; }
        public DateTime DateEffective { get; set; }
        public decimal Price { get; set; }
    }
}
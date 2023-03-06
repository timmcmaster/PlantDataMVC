using System;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class SaleEventStockDataModel : IDataModel
    {
        public int Id { get; set; }
        public int SaleEventId { get; set; }
        public int SpeciesId { get; set; }
        public int ProductTypeId { get; set; }
        public string GenusName { get; set; }
        public string SpeciesName { get; set; }
        public string ProductTypeName { get; set; }
        public int Quantity { get; set; }
    }
}
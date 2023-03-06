using System;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class CreateUpdateSaleEventStockDataModel : IDataModel
    {
        public int SaleEventId { get; set; }
        public int SpeciesId { get; set; }
        public int ProductTypeId { get; set; }
        public int Quantity { get; set; }
    }
}
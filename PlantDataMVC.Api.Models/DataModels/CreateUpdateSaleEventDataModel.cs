using System;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class CreateUpdateSaleEventDataModel : IDataModel
    {
        public string Name { get; set; }
        public DateTime SaleDate { get; set; }
        public string Location { get; set; }
    }
}
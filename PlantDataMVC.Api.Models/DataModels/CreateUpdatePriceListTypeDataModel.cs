using System;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class CreateUpdatePriceListTypeDataModel : IDataModel
    {
        public string Name { get; set; }
        public string Kind { get; set; }
    }
}
﻿using System.Collections.Generic;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class PriceListTypeDataModel : IDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public ICollection<ProductPriceDataModel> ProductPrices { get; set; }
    }
}
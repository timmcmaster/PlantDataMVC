using PlantDataMVC.Api.Models;
using System;
using System.Collections.Generic;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class SaleEventDataModel : IDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime SaleDate { get; set; }
        public string Location { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class StocktakeDataModel : IDataModel
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public DateTime StocktakeDate { get; set; }
        public IEnumerable<StocktakeLineDataModel> Lines { get; set; }
    }
}
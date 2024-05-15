using System;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class CreateUpdateStocktakeHeaderDataModel : IDataModel
    {
        public string Reference { get; set; }
        public DateTime StocktakeDate { get; set; }
    }
}
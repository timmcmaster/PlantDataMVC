using System;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class CreateUpdateStocktakeLineDataModel : IDataModel
    {
        public int HeaderId { get; set; }
        public int SpeciesId { get; set; }
        public int ProductTypeId { get; set; }
        public int ExpectedQuantity { get; set; }
        public int CountedQuantity { get; set; }
        public bool Applied {  get; set; }
    }
}
using System;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class StocktakeLineDataModel : IDataModel
    {
        public int Id { get; set; }
        public int HeaderId { get; set; }
        public int SpeciesId { get; set; }
        public int ProductTypeId { get; set; }
        public string GenusName { get; set; }
        public string SpeciesName { get; set; }
        public string ProductTypeName { get; set; }
        public int ExpectedQuantity { get; set; }
        public int CountedQuantity { get; set; }
        public bool Applied {  get; set; }
    }
}
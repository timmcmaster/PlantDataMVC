using System.Collections.Generic;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class PlantStockDataModel : IDto
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }
        public string GenusName { get; set; }
        public string SpeciesName { get; set; }
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public int QuantityInStock { get; set; }
        public ICollection<JournalEntryDataModel> JournalEntries { get; set; }
    }
}
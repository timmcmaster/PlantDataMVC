using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Repository.Models
{
    public class JournalEntryStockSummaryDataModel
    {
        public int SpeciesId { get; set; }
        public int ProductTypeId { get; set; }
        public string GenusName { get; set; }
        public string SpeciesName { get; set; }
        public string ProductTypeName { get; set; }
        public int QuantityInStock { get; set; }
    }
}

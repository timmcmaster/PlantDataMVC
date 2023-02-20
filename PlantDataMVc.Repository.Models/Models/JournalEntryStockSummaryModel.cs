using PlantDataMVC.Entities.EntityModels;

namespace PlantDataMVC.Repository.Models
{
    public class JournalEntryStockSummaryModel
    {
        public int SpeciesId { get; set; }
        public int ProductTypeId { get; set; }
        public string GenusName { get; set; } = string.Empty;
        public string SpeciesName { get; set; } = string.Empty;
        public string ProductTypeName { get; set; } = string.Empty;
        public int QuantityInStock { get; set; }
        public ICollection<JournalEntryEntityModel> JournalEntries { get; set; } = new List<JournalEntryEntityModel>();
    }
}

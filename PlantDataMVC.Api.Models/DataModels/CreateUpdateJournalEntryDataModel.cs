using System;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class CreateUpdateJournalEntryDataModel : IDataModel
    {
        public int SpeciesId { get; set; }
        public int ProductTypeId { get; set; }
        public int JournalEntryTypeId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Quantity { get; set; }
        public int? SeedTrayId { get; set; }
        public string Source { get; set; }
        public string Notes { get; set; }
    }
}
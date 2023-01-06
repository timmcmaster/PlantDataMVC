using PlantDataMVC.Api.Models;
using System;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class JournalEntryDataModel : IDataModel
    {
        public int Id { get; set; }
        public int PlantStockId { get; set; }
        public int JournalEntryTypeId { get; set; }
        public string JournalEntryTypeName { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Quantity { get; set; }
        public int? SeedTrayId { get; set; }
        public string Source { get; set; }
        public string Notes { get; set; }
    }
}
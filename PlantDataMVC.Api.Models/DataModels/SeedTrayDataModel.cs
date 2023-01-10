using System;
using System.Collections.Generic;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class SeedTrayDataModel : IDataModel
    {
        public int Id { get; set; }
        public int SeedBatchId { get; set; }
        public string SeedBatchGenusName { get; set; }
        public string SeedBatchSpeciesName { get; set; }
        public DateTime SeedBatchDateCollected { get; set; }
        public string SeedBatchLocation { get; set; }
        public DateTime DateSown { get; set; }
        public string Treatment { get; set; }
        public bool ThrownOut { get; set; }
        public ICollection<JournalEntryDataModel> JournalEntries { get; set; }
    }
}
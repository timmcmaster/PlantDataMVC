using System;
using System.Collections.Generic;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class SeedTrayDataModel : IDataModel
    {
        public int Id { get; set; }
        public int SeedBatchId { get; set; }
        public string GenusName { get; set; }
        public string SpeciesName { get; set; }
        public DateTime DatePlanted { get; set; }
        public string Treatment { get; set; }
        public bool ThrownOut { get; set; }
        public ICollection<JournalEntryDataModel> JournalEntries { get; set; }
    }
}
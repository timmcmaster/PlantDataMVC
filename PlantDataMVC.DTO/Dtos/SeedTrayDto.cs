using System;
using System.Collections.Generic;

namespace PlantDataMVC.DTO.Dtos
{
    public class SeedTrayDto : IDto
    {
        public int Id { get; set; }
        public int SeedBatchId { get; set; }
        public string GenusName { get; set; }
        public string SpeciesName { get; set; }
        public DateTime DatePlanted { get; set; }
        public string Treatment { get; set; }
        public bool ThrownOut { get; set; }
        public ICollection<JournalEntryDto> JournalEntries { get; set; }
    }
}
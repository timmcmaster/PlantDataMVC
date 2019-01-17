using System;
using System.Collections.Generic;
using Interfaces.DTO;

namespace PlantDataMVC.DTO.Dtos
{
    public class SeedTrayDto: IDto
    {
        public int Id { get; set; }
        public int SeedBatchId { get; set; }
        public DateTime DatePlanted { get; set; }
        public string Treatment { get; set; }
        public bool ThrownOut { get; set; }
        public ICollection<JournalEntryDto> JournalEntries { get; set; }
    }
}

﻿using Interfaces.DTO;
using System;
using System.Collections.Generic;

namespace PlantDataMVC.DTO.Entities
{
    public class SeedTrayDTO: IDtoEntity
    {
        public int Id { get; set; }
        public int SeedBatchId { get; set; }
        public DateTime DatePlanted { get; set; }
        public string Treatment { get; set; }
        public bool ThrownOut { get; set; }
        public ICollection<JournalEntryDTO> JournalEntries { get; set; }
    }
}

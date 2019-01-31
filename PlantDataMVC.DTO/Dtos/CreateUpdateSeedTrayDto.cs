using System;
using System.Collections.Generic;
using Interfaces.DTO;

namespace PlantDataMVC.DTO.Dtos
{
    public class CreateUpdateSeedTrayDto: IDto
    {
        public int SeedBatchId { get; set; }
        public DateTime DatePlanted { get; set; }
        public string Treatment { get; set; }
        public bool ThrownOut { get; set; }
    }
}
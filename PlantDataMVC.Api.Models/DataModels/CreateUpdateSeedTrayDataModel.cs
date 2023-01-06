using PlantDataMVC.Api.Models;
using System;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class CreateUpdateSeedTrayDataModel : IDto
    {
        public int SeedBatchId { get; set; }
        public DateTime DatePlanted { get; set; }
        public string Treatment { get; set; }
        public bool ThrownOut { get; set; }
    }
}
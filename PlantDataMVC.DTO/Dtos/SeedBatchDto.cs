using PlantDataMVC.DTO.DomainFunctions;
using System;
using System.Collections.Generic;

namespace PlantDataMVC.DTO.Dtos
{
    public class SeedBatchDto : IDto
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }
        public string GenusName { get; set; }
        public string SpeciesName { get; set; }
        public string SpeciesBinomial
        {
            get
            {
                return SpeciesFunctions.GetBinomial(GenusName, SpeciesName);
            }
        }
        public DateTime DateCollected { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public int? SiteId { get; set; }
        public string SiteName { get; set; }
        public ICollection<SeedTrayDto> SeedTrays { get; set; }
    }
}
﻿using PlantDataMVC.DTO.DomainFunctions;
using System.Collections.Generic;

namespace PlantDataMVC.DTO.Dtos
{
    public class SpeciesDto : IDto
    {
        public int Id { get; set; }
        public int GenusId { get; set; }
        public string GenusName { get; set; }
        public string SpecificName { get; set; }
        public string Binomial
        {
            get
            {
                return SpeciesFunctions.GetBinomial(GenusName,SpecificName);
            }
        }
        public string CommonName { get; set; }
        public string Description { get; set; }
        public int? PropagationTime { get; set; }
        public bool Native { get; set; }
        public ICollection<PlantStockDto> PlantStocks { get; set; }
        public ICollection<SeedBatchDto> SeedBatches { get; set; }
    }
}
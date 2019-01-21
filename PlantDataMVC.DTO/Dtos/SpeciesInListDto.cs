using System.Collections.Generic;
using Interfaces.DTO;

namespace PlantDataMVC.DTO.Dtos
{
    public class SpeciesInListDto : IDto
    {
        public int Id { get; set; }
        public int GenusId { get; set; } 
        public string SpecificName { get; set; } 
        public string CommonName { get; set; } 
    }
}

using System.Collections.Generic;

namespace PlantDataMVC.DTO.Dtos
{
    public class GenusDto : IDto
    {
        public int Id { get; set; }
        public string LatinName { get; set; }
        public ICollection<SpeciesDto> Species { get; set; }
    }
}
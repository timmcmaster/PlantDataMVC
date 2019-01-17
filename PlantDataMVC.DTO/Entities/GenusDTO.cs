using Interfaces.DTO;
using System.Collections.Generic;

namespace PlantDataMVC.DTO.Entities
{
    public class GenusDto : IDtoEntity
    {
        public int Id { get; set; }
        public string LatinName { get; set; }
        public ICollection<SpeciesDto> Species { get; set; }
    }
}

using Interfaces.DTO;
using System.Collections.Generic;

namespace PlantDataMVC.DTO.Entities
{
    public class GenusDTO : IDtoEntity
    {
        public int Id { get; set; }
        public string LatinName { get; set; }
        public ICollection<SpeciesDTO> Species { get; set; }
    }
}

using System.Collections.Generic;

namespace PlantDataMVC.DTO.Entities
{
    public class GenusDTO : DtoEntity
    {
        public string LatinName { get; set; }

        ICollection<SpeciesDTO> Species { get; set; }
    }
}

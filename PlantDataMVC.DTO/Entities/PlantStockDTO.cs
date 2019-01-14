using System.Collections.Generic;

namespace PlantDataMVC.DTO.Entities
{
    public class PlantStockDTO: DtoEntity
    {
        public int SpeciesId { get; set; }

        public int ProductTypeId { get; set; }

        public int QuantityInStock { get; set; }

        public ICollection<JournalEntryDTO> JournalEntries { get; set; }
    }
}

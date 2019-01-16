using Interfaces.DTO;
using System.Collections.Generic;

namespace PlantDataMVC.DTO.Entities
{
    public class PlantStockDTO: IDtoEntity
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }
        public int ProductTypeId { get; set; }
        public int QuantityInStock { get; set; }
        public ICollection<JournalEntryDTO> JournalEntries { get; set; }
    }
}

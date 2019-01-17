using System.Collections.Generic;
using Interfaces.DTO;

namespace PlantDataMVC.DTO.Dtos
{
    public class PlantStockDto: IDto
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }
        public int ProductTypeId { get; set; }
        public int QuantityInStock { get; set; }
        public ICollection<JournalEntryDto> JournalEntries { get; set; }
    }
}

using PlantDataMVC.DTO.DomainFunctions;
using System.Collections.Generic;

namespace PlantDataMVC.DTO.Dtos
{
    public class PlantStockDto : IDto
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }
        public string GenusName { get; set; }
        public string SpeciesName { get; set; }
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public int QuantityInStock { get; set; }
        public ICollection<JournalEntryDto> JournalEntries { get; set; }
    }
}
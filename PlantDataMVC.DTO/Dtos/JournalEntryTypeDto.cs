using Interfaces.DTO;

namespace PlantDataMVC.DTO.Dtos
{
    public class JournalEntryTypeDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Effect { get; set; }
    }
}
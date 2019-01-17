using Interfaces.DTO;
using System.Collections.Generic;

namespace PlantDataMVC.DTO.Entities
{
    public class JournalEntryTypeDto: IDtoEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Effect { get; set; }
    }
}

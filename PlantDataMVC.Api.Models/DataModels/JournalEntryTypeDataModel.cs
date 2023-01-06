using PlantDataMVC.Api.Models;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class JournalEntryTypeDataModel : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Effect { get; set; }
    }
}
namespace PlantDataMVC.Api.Models.DataModels
{
    public class JournalEntryTypeDataModel : IDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Effect { get; set; }
    }
}
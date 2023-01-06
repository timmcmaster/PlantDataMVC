using PlantDataMVC.Api.Models;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class GenusInListDataModel : IDataModel
    {
        public int Id { get; set; }
        public string LatinName { get; set; }
    }
}
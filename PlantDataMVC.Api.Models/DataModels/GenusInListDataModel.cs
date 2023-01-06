using PlantDataMVC.Api.Models;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class GenusInListDataModel : IDto
    {
        public int Id { get; set; }
        public string LatinName { get; set; }
    }
}
using PlantDataMVC.Api.Models;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class ProductTypeDataModel : IDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
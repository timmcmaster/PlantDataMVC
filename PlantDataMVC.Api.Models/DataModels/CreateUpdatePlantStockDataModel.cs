using PlantDataMVC.Api.Models;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class CreateUpdatePlantStockDataModel : IDto
    {
        public int SpeciesId { get; set; }
        public int ProductTypeId { get; set; }
        public int QuantityInStock { get; set; }
    }
}
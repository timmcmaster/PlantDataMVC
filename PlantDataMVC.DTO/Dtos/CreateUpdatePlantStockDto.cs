using Interfaces.DTO;

namespace PlantDataMVC.DTO.Dtos
{
    public class CreateUpdatePlantStockDto : IDto
    {
        public int SpeciesId { get; set; }
        public int ProductTypeId { get; set; }
        public int QuantityInStock { get; set; }
    }
}
using Interfaces.DTO;

namespace PlantDataMVC.DTO.Dtos
{
    public class ProductTypeDto: IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

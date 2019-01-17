using Interfaces.DTO;

namespace PlantDataMVC.DTO.Entities
{
    public class ProductTypeDto: IDtoEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

using Interfaces.DTO;

namespace PlantDataMVC.DTO.Entities
{
    public class ProductTypeDTO: IDtoEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

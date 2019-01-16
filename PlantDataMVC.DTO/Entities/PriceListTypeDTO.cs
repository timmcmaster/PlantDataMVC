using Interfaces.DTO;
using System.Collections.Generic;

namespace PlantDataMVC.DTO.Entities
{
    public class PriceListTypeDTO: IDtoEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public ICollection<ProductPriceDTO> ProductPrices { get; set; }
    }
}

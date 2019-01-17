using Interfaces.DTO;
using System.Collections.Generic;

namespace PlantDataMVC.DTO.Entities
{
    public class PriceListTypeDto: IDtoEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public ICollection<ProductPriceDto> ProductPrices { get; set; }
    }
}

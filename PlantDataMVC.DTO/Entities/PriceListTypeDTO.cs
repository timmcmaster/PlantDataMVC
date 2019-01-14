using System.Collections.Generic;

namespace PlantDataMVC.DTO.Entities
{
    public class PriceListTypeDTO: DtoEntity
    {
        public string Name { get; set; }

        public string Kind { get; set; }

        public ICollection<ProductPriceDTO> ProductPrices { get; set; }
    }
}

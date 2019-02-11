using System.Collections.Generic;

namespace PlantDataMVC.DTO.Dtos
{
    public class PriceListTypeDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public ICollection<ProductPriceDto> ProductPrices { get; set; }
    }
}
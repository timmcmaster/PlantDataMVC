using System;

namespace PlantDataMVC.DTO.Entities
{
    public class ProductPriceDTO
    {
        public int ProductTypeId { get; set; }

        public int PriceListTypeId { get; set; }

        public DateTime DateEffective { get; set; }

        public decimal Price { get; set; }
    }
}

using Interfaces.DTO;
using System;

namespace PlantDataMVC.DTO.Entities
{
    public class ProductPriceDto: IDtoEntity
    {
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public int PriceListTypeId { get; set; }
        public DateTime DateEffective { get; set; }
        public decimal Price { get; set; }
    }
}

using System;
using Interfaces.DTO;

namespace PlantDataMVC.DTO.Dtos
{
    public class ProductPriceDto : IDto
    {
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public int PriceListTypeId { get; set; }
        public DateTime DateEffective { get; set; }
        public decimal Price { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace PlantDataMVC.DTO.Dtos
{
    public class CreateUpdateSaleEventDto : IDto
    {
        public string Name { get; set; }
        public DateTime SaleDate { get; set; }
        public string Location { get; set; }
    }
}
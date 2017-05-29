using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.Core.Domain.BusinessObjects;

namespace PlantDataMVC.UI.Models
{
    public class PlantStockEntryUpdateEditModel
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }
        public int ProductTypeId { get; set; }
        public int QuantityInStock { get; set; }
    }
}

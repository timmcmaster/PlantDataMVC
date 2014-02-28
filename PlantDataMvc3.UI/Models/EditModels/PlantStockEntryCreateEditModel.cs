using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMvc3.Core.Domain.BusinessObjects;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMvc3.UI.Models
{
    public class PlantStockEntryCreateEditModel
    {
        public int SpeciesId { get; set; }
        public int ProductTypeId { get; set; }
        public int QuantityInStock { get; set; }
    }
}

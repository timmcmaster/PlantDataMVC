using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using PlantDataMVC.Core.Domain.BusinessObjects;

namespace PlantDataMVC.UI.Models
{
    public class PlantStockEntryNewViewModel
    {
        public List<PlantProductType> ProductTypes { get; set; }

        [Display(Name = "Species Id")]
        public int SpeciesId { get; set; }

        [Display(Name = "Product Type")]
        public int ProductTypeId { get; set; }

        [Display(Name = "Quantity In Stock"), Editable(false)]
        public int QuantityInStock { get; set; }
    }
}

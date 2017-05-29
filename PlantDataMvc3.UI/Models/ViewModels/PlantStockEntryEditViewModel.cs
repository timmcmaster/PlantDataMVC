using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using PlantDataMVC.Core.Domain.BusinessObjects;

namespace PlantDataMvc3.UI.Models
{
    public class PlantStockEntryEditViewModel
    {
        public List<PlantProductType> ProductTypes { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Species Id")]
        public int SpeciesId { get; set; }

        [Display(Name = "Product Type")]
        public int ProductTypeId { get; set; }

        [Display(Name = "Quantity In Stock"),  Editable(false)]
        public int QuantityInStock { get; set; }
    }
}

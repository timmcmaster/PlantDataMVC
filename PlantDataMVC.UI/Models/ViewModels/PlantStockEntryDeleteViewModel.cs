using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.Domain.Entities;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.UI.Models
{
    public class PlantStockEntryDeleteViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int SpeciesId { get; set; }

        [Display(Name = "Species Name")]
        public string SpeciesBinomial { get; private set; }

        [Display(Name = "Product Type")]
        public string ProductTypeName { get; set; }

        [Display(Name = "Quantity In Stock")]
        public int QuantityInStock { get; set; }
    }
}

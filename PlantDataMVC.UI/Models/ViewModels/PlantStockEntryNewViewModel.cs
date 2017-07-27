using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using PlantDataMVC.Domain.Entities;

namespace PlantDataMVC.UI.Models
{
    public class PlantStockEntryNewViewModel
    {
        //public List<PlantProductType> ProductTypes { get; set; }

        // TODO: Use dropdown for selection
        [Display(Name = "Species Id")]
        public int SpeciesId { get; set; }

        [Display(Name = "Species Name")]
        public string SpeciesBinomial { get; private set; }

        //[Display(Name = "Product Type Id")]
        //public int ProductTypeId { get; set; }

        [Display(Name = "Product Type")]
        public PlantProductType ProductType { get; set; }

        [Display(Name = "Quantity In Stock"), Editable(false)]
        public int QuantityInStock { get; set; }


        public PlantStockEntryNewViewModel()
        {
            ProductType = new PlantProductType();
        }
    }
}

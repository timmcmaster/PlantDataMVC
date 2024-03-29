﻿using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.UI.Models.ViewModels.PlantStock
{
    public class PlantStockNewViewModel
    {
        //[Display(Name = "Species Name")]
        //public SpeciesDto PlantSpecies { get; set; }

        [Display(Name = "Species Name")]
        public int SpeciesId { get; set; }

        //[Display(Name = "Product Type")]
        //public ProductTypeDto ProductType { get; set; }

        [Display(Name = "Product Type")]
        public int ProductTypeId { get; set; }

        [Display(Name = "Quantity In Stock"), Editable(false)]
        public int QuantityInStock { get; set; }


        public PlantStockNewViewModel()
        {
            //PlantSpecies = new SpeciesDto();
            //ProductType = new ProductTypeDto();
        }
    }
}

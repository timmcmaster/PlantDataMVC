﻿using PlantDataMVC.DTO.Entities;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.UI.Models.ViewModels
{
    public class PlantStockEntryNewViewModel
    {
        [Display(Name = "Species Name")]
        public Plant PlantSpecies { get; set; }

        [Display(Name = "Product Type")]
        public ProductTypeDTO ProductType { get; set; }

        [Display(Name = "Quantity In Stock"), Editable(false)]
        public int QuantityInStock { get; set; }


        public PlantStockEntryNewViewModel()
        {
            this.PlantSpecies = new Plant();
            this.ProductType = new ProductTypeDTO();
        }
    }
}

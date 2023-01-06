﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.Web.Models.ViewModels.PlantStock
{
    public class PlantStockShowViewModel
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

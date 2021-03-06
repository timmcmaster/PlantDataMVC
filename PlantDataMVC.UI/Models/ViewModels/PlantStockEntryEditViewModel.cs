﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using PlantDataMVC.Domain.Entities;

namespace PlantDataMVC.UI.Models
{
    public class PlantStockEntryEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int SpeciesId { get; set; }

        [Display(Name = "Species Name")]
        public string SpeciesBinomial { get; private set; }

        [Display(Name = "Product Type")]
        public PlantProductType ProductType { get; set; }

        [Display(Name = "Quantity In Stock"),  Editable(false)]
        public int QuantityInStock { get; set; }


        public PlantStockEntryEditViewModel()
        {
            ProductType = new PlantProductType();
        }
    }
}

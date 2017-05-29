﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.Core.Domain.BusinessObjects;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMvc3.UI.Models
{
    public class PlantStockEntryListViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Species Id")]
        public int SpeciesId { get; set; }

        [Display(Name = "Product Type")]
        public String ProductTypeName { get; set; }

        [Display(Name = "Quantity In Stock")]
        public int QuantityInStock { get; set; }
    }
}

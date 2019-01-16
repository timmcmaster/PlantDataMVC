﻿using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Models.ViewModels
{
    public class GenusNewViewModel
    {
        [Display(Name = "Latin Name"), StringLength(30), DataType("CustomString")]
        public string LatinName { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.Web.Models.ViewModels.StocktakeHeader
{
    public class StocktakeHeaderListViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; private set; }

        [StringLength(50), DataType("CustomString")]
        public string Reference { get; private set; }

        [Display(Name = "Stocktake Date"), StringLength(50), DataType("CustomString")]
        public DateTime StocktakeDate { get; private set; }
    }
}

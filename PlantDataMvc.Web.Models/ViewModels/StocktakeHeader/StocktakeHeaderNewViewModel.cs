using System;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Web.Models.ViewModels.StocktakeHeader
{
    public class StocktakeHeaderNewViewModel
    {
        [StringLength(50), DataType("CustomString")]
        public string Reference { get; private set; }

        [Display(Name = "Stocktake Date"), StringLength(50), DataType("CustomString")]
        public DateTime StocktakeDate { get; private set; }
    }
}

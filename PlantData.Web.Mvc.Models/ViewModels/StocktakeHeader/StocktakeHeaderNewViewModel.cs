using System;
using System.ComponentModel.DataAnnotations;

namespace PlantData.Web.Mvc.Models.ViewModels.StocktakeHeader
{
    public class StocktakeHeaderNewViewModel
    {
        [StringLength(50), DataType("CustomString")]
        public string Reference { get; private set; }

        [Display(Name = "Stocktake Date"), StringLength(50), DataType("CustomString")]
        public DateTime StocktakeDate { get; private set; }
    }
}

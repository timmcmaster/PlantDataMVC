using System.ComponentModel.DataAnnotations;


namespace PlantDataMVC.Web.Models.ViewModels.Transaction
{
    public class TransactionStocktakeListViewModel
    {
        [Display(Name = "Species Name")]
        public int SpeciesId { get; set; }

        [Display(Name = "Product Type")]
        public int ProductTypeId { get; set; }

        [Display(Name = "Species Name")]
        public string SpeciesBinomial { get; private set; }

        [Display(Name = "Product Type")]
        public string ProductTypeName { get; set; }

        [Display(Name = "Stock Qty")]
        public int QuantityInStock { get; set; }

        [Display(Name = "Counted Qty")]
        public int CountedQuantity { get; set; }

        [Display(Name = "Discrepancy")]
        public int Discrepancy { get; set; } 

        [Display(Name = "Reason")]
        public string Reason { get; set; }

        [Display(Name = "Stock")]
        public bool IsStock { get; set; }

        public TransactionStocktakeListViewModel()
        {
        }
    }
}

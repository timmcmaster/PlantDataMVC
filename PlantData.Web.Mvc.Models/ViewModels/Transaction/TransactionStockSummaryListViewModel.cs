using System.ComponentModel.DataAnnotations;


namespace PlantData.Web.Mvc.Models.ViewModels.Transaction
{
    public class TransactionStockSummaryListViewModel
    {
        [Display(Name = "Species Id")]
        public int SpeciesId { get; set; }

        [Display(Name = "Product Type Id")]
        public int ProductTypeId { get; set; }

        [Display(Name = "Species Name")]
        public string SpeciesBinomial { get; private set; }

        [Display(Name = "Product Type")]
        public string ProductTypeName { get; set; }

        [Display(Name = "Quantity In Stock")]
        public int QuantityInStock { get; set; }

        public TransactionStockSummaryListViewModel()
        {
        }
    }
}

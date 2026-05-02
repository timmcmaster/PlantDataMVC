using System.ComponentModel.DataAnnotations;

namespace PlantData.Web.Blazor.UIModels.ViewModels.Transaction
{
    public class StockSummaryGridModel
    {
        [Display(Name = "Species Id")]
        public int SpeciesId { get; set; }

        [Display(Name = "Product Type Id")]
        public int ProductTypeId { get; set; }

        [Display(Name = "Genus")]
        public string GenusName { get; set; }

        [Display(Name = "Species Name")]
        public string SpeciesName { get; set; }

        [Display(Name = "Species Binomial")]
        public string SpeciesBinomial
        {
            get
            {
                if (string.IsNullOrEmpty(GenusName) || string.IsNullOrEmpty(SpeciesName))
                    return "";
                return $"{GenusName} {SpeciesName}";
            }
        }

        [Display(Name = "Product Type")]
        public string ProductTypeName { get; set; }

        [Display(Name = "Quantity In Stock")]
        public int QuantityInStock { get; set; }
    }
}

using PlantDataMVC.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.UI.Models
{
    public class PlantStockEntryNewViewModel
    {
        // TODO: Use dropdown for selection
        [Display(Name = "Species Name")]
        public Plant PlantSpecies { get; set; }

        //[Display(Name = "Species Id")]
        //public int SpeciesId { get; set; }

        //[Display(Name = "Species Name")]
        //public string SpeciesBinomial { get; private set; }

        [Display(Name = "Product Type")]
        public PlantProductType ProductType { get; set; }

        [Display(Name = "Quantity In Stock"), Editable(false)]
        public int QuantityInStock { get; set; }


        public PlantStockEntryNewViewModel()
        {
            this.PlantSpecies = new Plant();
            this.ProductType = new PlantProductType();
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.UICore.Models.ViewModels.PlantStock
{
    public class PlantStockNewViewModel
    {
        //[Display(Name = "Species Name")]
        //public SpeciesDataModel PlantSpecies { get; set; }

        [Display(Name = "Species Name")]
        public int SpeciesId { get; set; }

        //[Display(Name = "Product Type")]
        //public ProductTypeDataModel ProductType { get; set; }

        [Display(Name = "Product Type")]
        public int ProductTypeId { get; set; }

        [Display(Name = "Quantity In Stock"), Editable(false)]
        public int QuantityInStock { get; set; }


        public PlantStockNewViewModel()
        {
            //PlantSpecies = new SpeciesDataModel();
            //ProductType = new ProductTypeDataModel();
        }
    }
}

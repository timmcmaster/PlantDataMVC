using System.ComponentModel.DataAnnotations;
using Framework.Web.Views;
using PlantDataMVC.DTO.Dtos;

namespace PlantDataMVC.UI.Models.ViewModels
{
    public class PlantStockNewViewModel
    {
        [Display(Name = "Species Name")]
        public SpeciesDto PlantSpecies { get; set; }

        [Display(Name = "Product Type")]
        public ProductTypeDto ProductType { get; set; }

        [Display(Name = "Quantity In Stock"), Editable(false)]
        public int QuantityInStock { get; set; }


        public PlantStockNewViewModel()
        {
            PlantSpecies = new SpeciesDto();
            ProductType = new ProductTypeDto();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace PlantData.Web.Mvc.Models.ViewModels.ProductType
{
    public class ProductTypeDeleteViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
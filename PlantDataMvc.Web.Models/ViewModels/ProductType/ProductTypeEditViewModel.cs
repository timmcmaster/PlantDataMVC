using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.Web.Models.ViewModels.ProductType
{
    public class ProductTypeEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Name"), StringLength(50), DataType("CustomString")]
        public string Name { get; set; }
    }
}
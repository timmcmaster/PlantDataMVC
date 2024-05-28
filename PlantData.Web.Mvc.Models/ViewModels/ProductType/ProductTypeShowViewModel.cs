using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PlantData.Web.Mvc.Models.ViewModels.ProductType
{
    public class ProductTypeShowViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; private set; }

        [Display(Name = "Name")]
        public string Name { get; private set; }

    }
}
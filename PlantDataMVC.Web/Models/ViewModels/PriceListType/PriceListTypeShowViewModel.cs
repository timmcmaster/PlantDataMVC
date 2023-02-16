using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.Web.Models.ViewModels.PriceListType
{
    public class PriceListTypeShowViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; private set; }

        [Display(Name = "Name")]
        public string Name { get; private set; }

        [Display(Name = "Kind")]
        public string Kind { get; private set; }
    }
}
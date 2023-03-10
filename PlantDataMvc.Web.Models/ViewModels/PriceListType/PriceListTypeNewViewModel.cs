using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Web.Models.ViewModels.PriceListType
{
    public class PriceListTypeNewViewModel
    {
        [Display(Name = "Name"), StringLength(50), DataType("CustomString")]
        public string Name { get; set; }

        [Display(Name = "Kind"), StringLength(1), DataType("CustomString")]
        public string Kind { get; set; }
    }
}
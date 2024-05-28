using System.ComponentModel.DataAnnotations;

namespace PlantData.Web.Mvc.Models.ViewModels.ProductType
{
    public class ProductTypeNewViewModel
    {
        [Display(Name = "Name"), StringLength(50), DataType("CustomString")]
        public string Name { get; set; }
    }
}
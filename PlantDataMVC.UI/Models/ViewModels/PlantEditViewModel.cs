using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Framework.Web.Views;

namespace PlantDataMVC.UI.Models.ViewModels
{
    public class PlantEditViewModel : IViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required, StringLength(30), DataType("CustomString")]
        public string Genus { get; set; }

        [StringLength(30), DataType("CustomString")]
        public string Species { get; set; }

        [Display(Name = "Common Name"), StringLength(50), DataType("CustomString")]
        public string CommonName { get; set; }

        [StringLength(200), DataType("CustomString")]
        public string Description { get; set; }

        [Display(Name = "Propagation Time")]
        public int PropagationTime { get; set; }

        public bool Native { get; set; }
    }
}
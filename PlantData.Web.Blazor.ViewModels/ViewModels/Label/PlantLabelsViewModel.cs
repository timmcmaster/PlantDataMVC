using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PlantData.Web.Blazor.UIModels.ViewModels.Label
{
    public class PlantLabelsViewModel
    {
        [Display(Name = "Plant Labels"), Required]
        public IEnumerable<PlantLabelRequestGridModel> PlantLabelRequests { get; set; } = new List<PlantLabelRequestGridModel>();

        //public GridOptionsModel GridOptions { get; set; } = new();

    }
}

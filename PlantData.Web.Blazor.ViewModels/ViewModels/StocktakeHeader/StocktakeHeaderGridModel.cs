using System;

namespace PlantData.Web.Blazor.UIModels.ViewModels.StocktakeHeader
{
    public class StocktakeHeaderGridModel
    {
        public int Id { get; set; }

        public DateTime StocktakeDate { get; set; }

        public string Reference { get; set; }
    }
}

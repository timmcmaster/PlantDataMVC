using Framework.Web.Forms;
using System;

namespace PlantData.Web.Blazor.UIModels.EditModels.StocktakeHeader
{
    public class StocktakeHeaderCreateEditModel : IForm<bool>
    {
        public DateTime StocktakeDate { get; set; }

        public string Reference { get; set; }
    }
}

using Framework.Web.Forms;
using System;

namespace PlantData.Web.Mvc.Models.EditModels.StocktakeHeader
{
    public class StocktakeHeaderCreateEditModel : IForm<bool>
    {
        public string Reference { get; set; }
        public DateTime StocktakeDate { get; set; }
    }
}

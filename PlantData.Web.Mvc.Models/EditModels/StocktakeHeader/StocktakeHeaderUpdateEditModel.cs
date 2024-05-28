using Framework.Web.Forms;
using System;

namespace PlantData.Web.Mvc.Models.EditModels.StocktakeHeader
{
    public class StocktakeHeaderUpdateEditModel : IForm<bool>
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public DateTime StocktakeDate { get; set; }
    }
}

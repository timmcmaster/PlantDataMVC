using Framework.Web.Forms;
using System;

namespace PlantData.Web.Mvc.Models.EditModels.ProductPrice
{
    public class ProductPriceDestroyEditModel : IForm<bool>
    {
        public int Id { get; set; }
    }
}
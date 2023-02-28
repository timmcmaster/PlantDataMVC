using Framework.Web.Forms;
using System;

namespace PlantDataMVC.Web.Models.EditModels.ProductPrice
{
    public class ProductPriceDestroyEditModel : IForm<bool>
    {
        public int Id { get; set; }
    }
}
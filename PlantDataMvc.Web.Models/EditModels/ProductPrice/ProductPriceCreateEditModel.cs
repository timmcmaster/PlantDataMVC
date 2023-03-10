using Framework.Web.Forms;
using System;

namespace PlantDataMVC.Web.Models.EditModels.ProductPrice
{
    public class ProductPriceCreateEditModel : IForm<bool>
    {
        public int ProductTypeId { get; set; }
        public int PriceListTypeId { get; set; }
        public DateTime DateEffective { get; set; }
        public decimal Price { get; set; }
    }
}
using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.ProductPrice;
using System;

namespace PlantDataMVC.Web.Controllers.Queries.ProductPrice
{
    public class EditQuery : IQuery<ProductPriceEditViewModel>
    {
        public EditQuery(int productTypeId, int priceListTypeId, DateTime dateEffective)
        {
            ProductTypeId = productTypeId;
            PriceListTypeId = priceListTypeId;
            DateEffective = dateEffective;
        }

        public int ProductTypeId { get; set; }
        public int PriceListTypeId { get; set; }
        public DateTime DateEffective { get; set; }
    }
}
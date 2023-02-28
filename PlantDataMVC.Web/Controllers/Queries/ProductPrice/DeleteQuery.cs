using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.ProductPrice;
using System;

namespace PlantDataMVC.Web.Controllers.Queries.ProductPrice
{
    public class DeleteQuery : IQuery<ProductPriceDeleteViewModel>
    {

        public DeleteQuery(int productTypeId, int priceListTypeId, DateTime dateEffective)
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
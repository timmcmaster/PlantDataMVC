using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.ProductPrice;
using System;

namespace PlantDataMVC.Web.Controllers.Queries.ProductPrice
{
    public class ShowQuery : IQuery<ProductPriceShowViewModel>
    {
        public ShowQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
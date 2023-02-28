using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.ProductPrice;
using System;

namespace PlantDataMVC.Web.Controllers.Queries.ProductPrice
{
    public class DeleteQuery : IQuery<ProductPriceDeleteViewModel>
    {
        public DeleteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
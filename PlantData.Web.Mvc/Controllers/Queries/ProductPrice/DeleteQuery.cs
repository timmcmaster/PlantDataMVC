using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels.ProductPrice;
using System;

namespace PlantData.Web.Mvc.Controllers.Queries.ProductPrice
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
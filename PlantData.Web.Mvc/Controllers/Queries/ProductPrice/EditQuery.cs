using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels.ProductPrice;
using System;

namespace PlantData.Web.Mvc.Controllers.Queries.ProductPrice
{
    public class EditQuery : IQuery<ProductPriceEditViewModel>
    {
        public EditQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
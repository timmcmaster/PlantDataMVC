using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.ProductPrice;
using System;

namespace PlantDataMVC.Web.Controllers.Queries.ProductPrice
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
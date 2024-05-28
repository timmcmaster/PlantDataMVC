using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels.ProductType;

namespace PlantData.Web.Mvc.Controllers.Queries.ProductType
{
    public class ShowQuery : IQuery<ProductTypeShowViewModel>
    {

        public ShowQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
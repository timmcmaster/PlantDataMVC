using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.ProductType;

namespace PlantDataMVC.Web.Controllers.Queries.ProductType
{
    public class DeleteQuery : IQuery<ProductTypeDeleteViewModel>
    {

        public DeleteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
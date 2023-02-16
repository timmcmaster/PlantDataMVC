using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.ProductType;

namespace PlantDataMVC.Web.Controllers.Queries.ProductType
{
    public class EditQuery : IQuery<ProductTypeEditViewModel>
    {

        public EditQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
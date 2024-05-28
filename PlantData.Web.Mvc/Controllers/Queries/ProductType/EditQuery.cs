using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels.ProductType;

namespace PlantData.Web.Mvc.Controllers.Queries.ProductType
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
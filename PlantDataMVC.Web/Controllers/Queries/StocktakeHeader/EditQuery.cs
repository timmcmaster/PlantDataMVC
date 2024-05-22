using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.StocktakeHeader;

namespace PlantDataMVC.Web.Controllers.Queries.StocktakeHeader
{
    public class EditQuery : IQuery<StocktakeHeaderEditViewModel>
    {
        public EditQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
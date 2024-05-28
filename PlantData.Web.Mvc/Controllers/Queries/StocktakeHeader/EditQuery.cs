using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels.StocktakeHeader;

namespace PlantData.Web.Mvc.Controllers.Queries.StocktakeHeader
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
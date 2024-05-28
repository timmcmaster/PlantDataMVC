using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels.StocktakeHeader;

namespace PlantData.Web.Mvc.Controllers.Queries.StocktakeHeader
{
    public class DeleteQuery : IQuery<StocktakeHeaderDeleteViewModel>
    {
        public DeleteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
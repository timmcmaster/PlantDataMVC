using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels.StocktakeHeader;

namespace PlantData.Web.Mvc.Controllers.Queries.StocktakeHeader
{
    public class ShowQuery : IQuery<StocktakeHeaderShowViewModel>
    {
        public ShowQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
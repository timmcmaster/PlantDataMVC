using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.StocktakeHeader;

namespace PlantDataMVC.Web.Controllers.Queries.StocktakeHeader
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
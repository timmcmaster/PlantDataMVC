using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.StocktakeHeader;

namespace PlantDataMVC.Web.Controllers.Queries.StocktakeHeader
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
using Framework.Web.Core.Views;
using PlantDataMVC.UICore.Models.ViewModels.PlantStock;

namespace PlantDataMVC.UICore.Controllers.Queries.PlantStock
{
    public class DetailsQuery : IQuery<PlantStockDetailsViewModel>
    {

        public DetailsQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.PlantStock;

namespace PlantDataMVC.Web.Controllers.Queries.PlantStock
{
    public class ShowQuery : IQuery<PlantStockShowViewModel>
    {
        public ShowQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
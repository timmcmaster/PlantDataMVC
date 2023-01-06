using Framework.Web.Views;
using PlantDataMVC.UICore.Models.ViewModels.PlantStock;

namespace PlantDataMVC.UICore.Controllers.Queries.PlantStock
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
using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels.PlantStock;

namespace PlantData.Web.Mvc.Controllers.Queries.PlantStock
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
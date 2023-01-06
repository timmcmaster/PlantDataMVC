using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.PlantStock;

namespace PlantDataMVC.Web.Controllers.Queries.PlantStock
{
    public class DeleteQuery : IQuery<PlantStockDeleteViewModel>
    {

        public DeleteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
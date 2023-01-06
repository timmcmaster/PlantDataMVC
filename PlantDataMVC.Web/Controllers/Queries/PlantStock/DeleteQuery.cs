using Framework.Web.Views;
using PlantDataMVC.UICore.Models.ViewModels.PlantStock;

namespace PlantDataMVC.UICore.Controllers.Queries.PlantStock
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
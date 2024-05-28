using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels.PlantStock;

namespace PlantData.Web.Mvc.Controllers.Queries.PlantStock
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
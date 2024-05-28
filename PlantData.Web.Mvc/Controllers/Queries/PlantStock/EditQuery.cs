using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels.PlantStock;

namespace PlantData.Web.Mvc.Controllers.Queries.PlantStock
{
    public class EditQuery : IQuery<PlantStockEditViewModel>
    {
        public EditQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
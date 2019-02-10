using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels.PlantStock;

namespace PlantDataMVC.UI.Controllers.Queries.PlantStock
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
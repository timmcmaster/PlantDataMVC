using Framework.Web.Views;
using PlantDataMVC.UICore.Models.ViewModels.PlantStock;

namespace PlantDataMVC.UICore.Controllers.Queries.PlantStock
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
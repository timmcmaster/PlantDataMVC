using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.PlantStock;

namespace PlantDataMVC.Web.Controllers.Queries.PlantStock
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
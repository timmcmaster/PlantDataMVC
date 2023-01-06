using Framework.Web.Views;
using PlantDataMVC.UICore.Models.ViewModels.SaleEvent;

namespace PlantDataMVC.UICore.Controllers.Queries.SaleEvent
{
    public class EditQuery : IQuery<SaleEventEditViewModel>
    {
        public EditQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
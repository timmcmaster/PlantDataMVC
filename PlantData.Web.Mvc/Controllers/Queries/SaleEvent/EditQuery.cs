using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels.SaleEvent;

namespace PlantData.Web.Mvc.Controllers.Queries.SaleEvent
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
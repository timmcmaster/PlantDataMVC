using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels.SaleEvent;

namespace PlantData.Web.Mvc.Controllers.Queries.SaleEvent
{
    public class ShowQuery : IQuery<SaleEventShowViewModel>
    {
        public ShowQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
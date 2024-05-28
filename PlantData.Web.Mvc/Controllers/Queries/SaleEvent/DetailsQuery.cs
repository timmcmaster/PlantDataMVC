using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels.SaleEvent;

namespace PlantData.Web.Mvc.Controllers.Queries.SaleEvent
{
    public class DetailsQuery : IQuery<SaleEventDetailsViewModel>
    {
        public DetailsQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
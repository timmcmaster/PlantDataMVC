using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.SaleEvent;

namespace PlantDataMVC.Web.Controllers.Queries.SaleEvent
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
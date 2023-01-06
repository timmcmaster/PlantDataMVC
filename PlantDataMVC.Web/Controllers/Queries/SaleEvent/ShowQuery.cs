using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.SaleEvent;

namespace PlantDataMVC.Web.Controllers.Queries.SaleEvent
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
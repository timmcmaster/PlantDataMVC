using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.PriceListType;

namespace PlantDataMVC.Web.Controllers.Queries.PriceListType
{
    public class ShowQuery : IQuery<PriceListTypeShowViewModel>
    {

        public ShowQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
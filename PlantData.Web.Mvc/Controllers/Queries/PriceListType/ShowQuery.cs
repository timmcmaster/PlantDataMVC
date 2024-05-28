using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels.PriceListType;

namespace PlantData.Web.Mvc.Controllers.Queries.PriceListType
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
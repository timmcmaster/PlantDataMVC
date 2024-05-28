using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels.PriceListType;

namespace PlantData.Web.Mvc.Controllers.Queries.PriceListType
{
    public class DetailsQuery : IQuery<PriceListTypeDetailsViewModel>
    {

        public DetailsQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
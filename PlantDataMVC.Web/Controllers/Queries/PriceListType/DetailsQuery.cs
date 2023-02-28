using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.PriceListType;

namespace PlantDataMVC.Web.Controllers.Queries.PriceListType
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
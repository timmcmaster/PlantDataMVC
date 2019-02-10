using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels.Seed;

namespace PlantDataMVC.UI.Controllers.Queries.Seed
{
    public class ShowQuery : IQuery<PlantSeedShowViewModel>
    {

        public ShowQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
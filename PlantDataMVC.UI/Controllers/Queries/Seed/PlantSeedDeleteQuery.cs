using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels.Seed;

namespace PlantDataMVC.UI.Controllers.Queries.Seed
{
    public class PlantSeedDeleteQuery : IViewQuery<PlantSeedDeleteViewModel>
    {

        public PlantSeedDeleteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
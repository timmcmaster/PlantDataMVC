using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels.Seed;

namespace PlantDataMVC.UI.Controllers.Queries.Seed
{
    public class PlantSeedEditQuery : IViewQuery<PlantSeedEditViewModel>
    {

        public PlantSeedEditQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
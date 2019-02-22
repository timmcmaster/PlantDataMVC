using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels.SeedTray;

namespace PlantDataMVC.UI.Controllers.Queries.SeedTray
{
    public class ShowQuery : IQuery<SeedTrayShowViewModel>
    {

        public ShowQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
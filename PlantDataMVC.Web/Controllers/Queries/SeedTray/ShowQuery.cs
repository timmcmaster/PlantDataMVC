using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.SeedTray;

namespace PlantDataMVC.Web.Controllers.Queries.SeedTray
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
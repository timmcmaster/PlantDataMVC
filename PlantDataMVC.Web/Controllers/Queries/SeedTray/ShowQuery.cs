using Framework.Web.Views;
using PlantDataMVC.UICore.Models.ViewModels.SeedTray;

namespace PlantDataMVC.UICore.Controllers.Queries.SeedTray
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
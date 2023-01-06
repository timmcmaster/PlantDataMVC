using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.SeedTray;

namespace PlantDataMVC.Web.Controllers.Queries.SeedTray
{
    public class EditQuery : IQuery<SeedTrayEditViewModel>
    {

        public EditQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels.SeedTray;

namespace PlantDataMVC.UI.Controllers.Queries.SeedTray
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
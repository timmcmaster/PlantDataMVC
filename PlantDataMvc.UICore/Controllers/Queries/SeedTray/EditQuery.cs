using Framework.Web.Core.Views;
using PlantDataMVC.UICore.Models.ViewModels.SeedTray;

namespace PlantDataMVC.UICore.Controllers.Queries.SeedTray
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
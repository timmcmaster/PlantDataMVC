using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels.Tray;

namespace PlantDataMVC.UI.Controllers.Queries.Tray
{
    public class TrayEditQuery : IViewQuery<TrayEditViewModel>
    {

        public TrayEditQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels.Tray;

namespace PlantDataMVC.UI.Controllers.Queries.Tray
{
    public class TrayShowQuery : IViewQuery<TrayShowViewModel>
    {

        public TrayShowQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
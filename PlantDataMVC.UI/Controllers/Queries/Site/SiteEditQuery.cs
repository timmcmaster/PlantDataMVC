using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels.Site;

namespace PlantDataMVC.UI.Controllers.Queries.Site
{
    public class SiteEditQuery : IViewQuery<SiteEditViewModel>
    {
        public SiteEditQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
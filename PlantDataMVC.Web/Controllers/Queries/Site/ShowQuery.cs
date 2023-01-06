using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.Site;

namespace PlantDataMVC.Web.Controllers.Queries.Site
{
    public class ShowQuery : IQuery<SiteShowViewModel>
    {
        public ShowQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
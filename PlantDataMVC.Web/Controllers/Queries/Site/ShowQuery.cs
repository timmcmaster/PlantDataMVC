using Framework.Web.Views;
using PlantDataMVC.UICore.Models.ViewModels.Site;

namespace PlantDataMVC.UICore.Controllers.Queries.Site
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
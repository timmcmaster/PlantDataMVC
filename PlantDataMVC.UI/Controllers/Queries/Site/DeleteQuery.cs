using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels.Site;

namespace PlantDataMVC.UI.Controllers.Queries.Site
{
    public class DeleteQuery : IQuery<SiteDeleteViewModel>
    {
        public DeleteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
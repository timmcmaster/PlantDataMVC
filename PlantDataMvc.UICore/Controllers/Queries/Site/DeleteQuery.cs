using Framework.Web.Core.Views;
using PlantDataMVC.UICore.Models.ViewModels.Site;

namespace PlantDataMVC.UICore.Controllers.Queries.Site
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
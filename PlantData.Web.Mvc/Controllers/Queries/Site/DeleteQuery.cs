using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels.Site;

namespace PlantData.Web.Mvc.Controllers.Queries.Site
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
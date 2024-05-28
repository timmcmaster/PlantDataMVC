using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels.Site;

namespace PlantData.Web.Mvc.Controllers.Queries.Site
{
    public class EditQuery : IQuery<SiteEditViewModel>
    {
        public EditQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
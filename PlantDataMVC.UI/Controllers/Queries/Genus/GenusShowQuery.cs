using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels.Genus;

namespace PlantDataMVC.UI.Controllers.Queries.Genus
{
    public class GenusShowQuery : IViewQuery<GenusShowViewModel>
    {

        public GenusShowQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
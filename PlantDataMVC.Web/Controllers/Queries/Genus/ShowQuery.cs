using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.Genus;

namespace PlantDataMVC.Web.Controllers.Queries.Genus
{
    public class ShowQuery : IQuery<GenusShowViewModel>
    {

        public ShowQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
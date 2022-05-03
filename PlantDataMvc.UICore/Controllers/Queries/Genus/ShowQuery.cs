using Framework.Web.Core.Views;
using PlantDataMVC.UICore.Models.ViewModels.Genus;

namespace PlantDataMVC.UICore.Controllers.Queries.Genus
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
using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels.Genus;

namespace PlantDataMVC.UI.Controllers.Queries.Genus
{
    public class DeleteQuery : IQuery<GenusDeleteViewModel>
    {

        public DeleteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
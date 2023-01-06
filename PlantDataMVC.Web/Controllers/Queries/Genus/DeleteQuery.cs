using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.Genus;

namespace PlantDataMVC.Web.Controllers.Queries.Genus
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
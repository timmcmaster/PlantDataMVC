using Framework.Web.Core.Views;
using PlantDataMVC.UICore.Models.ViewModels.Genus;

namespace PlantDataMVC.UICore.Controllers.Queries.Genus
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
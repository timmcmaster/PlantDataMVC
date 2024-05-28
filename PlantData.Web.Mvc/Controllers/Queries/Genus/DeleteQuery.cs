using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels.Genus;

namespace PlantData.Web.Mvc.Controllers.Queries.Genus
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
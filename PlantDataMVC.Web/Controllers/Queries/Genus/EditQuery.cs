using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.Genus;

namespace PlantDataMVC.Web.Controllers.Queries.Genus
{
    public class EditQuery : IQuery<GenusEditViewModel>
    {

        public EditQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
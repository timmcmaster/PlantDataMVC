using Framework.Web.Views;
using PlantDataMVC.UICore.Models.ViewModels.Genus;

namespace PlantDataMVC.UICore.Controllers.Queries.Genus
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
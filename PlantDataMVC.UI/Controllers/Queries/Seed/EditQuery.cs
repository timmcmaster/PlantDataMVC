using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels.Seed;

namespace PlantDataMVC.UI.Controllers.Queries.Seed
{
    public class EditQuery : IQuery<PlantSeedEditViewModel>
    {

        public EditQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
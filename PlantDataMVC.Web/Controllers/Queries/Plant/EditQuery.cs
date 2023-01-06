using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.Plant;

namespace PlantDataMVC.Web.Controllers.Queries.Plant
{
    public class EditQuery : IQuery<PlantEditViewModel>
    {

        public EditQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
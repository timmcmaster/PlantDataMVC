using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels.Plant;

namespace PlantDataMVC.UI.Controllers.Queries.Plant
{
    public class DeleteQuery : IQuery<PlantDeleteViewModel>
    {

        public DeleteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
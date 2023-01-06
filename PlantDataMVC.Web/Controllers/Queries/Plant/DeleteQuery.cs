using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.Plant;

namespace PlantDataMVC.Web.Controllers.Queries.Plant
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
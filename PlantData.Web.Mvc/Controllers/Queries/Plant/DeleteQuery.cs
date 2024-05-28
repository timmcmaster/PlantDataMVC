using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels.Plant;

namespace PlantData.Web.Mvc.Controllers.Queries.Plant
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
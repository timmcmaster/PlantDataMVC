using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.Plant;

namespace PlantDataMVC.Web.Controllers.Queries.Plant
{
    public class ShowQuery : IQuery<PlantShowViewModel>
    {

        public ShowQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
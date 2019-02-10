using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels.Plant;

namespace PlantDataMVC.UI.Controllers.Queries.Plant
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
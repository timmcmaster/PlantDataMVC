using Framework.Web.Views;
using PlantDataMVC.UICore.Models.ViewModels.Plant;

namespace PlantDataMVC.UICore.Controllers.Queries.Plant
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
using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels.SeedTray;

namespace PlantData.Web.Mvc.Controllers.Queries.SeedTray
{
    public class DeleteQuery : IQuery<SeedTrayDeleteViewModel>
    {

        public DeleteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
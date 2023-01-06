using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.SeedTray;

namespace PlantDataMVC.Web.Controllers.Queries.SeedTray
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
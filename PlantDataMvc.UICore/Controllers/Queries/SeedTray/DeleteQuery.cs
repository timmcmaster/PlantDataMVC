using Framework.Web.Core.Views;
using PlantDataMVC.UICore.Models.ViewModels.SeedTray;

namespace PlantDataMVC.UICore.Controllers.Queries.SeedTray
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
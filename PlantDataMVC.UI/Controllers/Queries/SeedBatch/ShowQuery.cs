using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels.SeedBatch;

namespace PlantDataMVC.UI.Controllers.Queries.SeedBatch
{
    public class ShowQuery : IQuery<SeedBatchShowViewModel>
    {

        public ShowQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
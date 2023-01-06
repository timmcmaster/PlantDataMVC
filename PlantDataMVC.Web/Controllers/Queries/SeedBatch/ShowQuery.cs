using Framework.Web.Views;
using PlantDataMVC.UICore.Models.ViewModels.SeedBatch;

namespace PlantDataMVC.UICore.Controllers.Queries.SeedBatch
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
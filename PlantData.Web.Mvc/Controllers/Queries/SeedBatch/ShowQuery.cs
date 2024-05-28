using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels.SeedBatch;

namespace PlantData.Web.Mvc.Controllers.Queries.SeedBatch
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
using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels.SeedBatch;

namespace PlantData.Web.Mvc.Controllers.Queries.SeedBatch
{
    public class DeleteQuery : IQuery<SeedBatchDeleteViewModel>
    {

        public DeleteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
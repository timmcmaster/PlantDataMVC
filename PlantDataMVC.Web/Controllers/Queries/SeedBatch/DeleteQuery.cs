using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.SeedBatch;

namespace PlantDataMVC.Web.Controllers.Queries.SeedBatch
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
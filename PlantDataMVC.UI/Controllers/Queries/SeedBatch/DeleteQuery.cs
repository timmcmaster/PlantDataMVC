using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels.SeedBatch;

namespace PlantDataMVC.UI.Controllers.Queries.SeedBatch
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
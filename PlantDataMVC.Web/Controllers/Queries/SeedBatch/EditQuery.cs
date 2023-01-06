using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.SeedBatch;

namespace PlantDataMVC.Web.Controllers.Queries.SeedBatch
{
    public class EditQuery : IQuery<SeedBatchEditViewModel>
    {

        public EditQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
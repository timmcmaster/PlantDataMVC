using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels.SeedBatch;

namespace PlantDataMVC.UI.Controllers.Queries.SeedBatch
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
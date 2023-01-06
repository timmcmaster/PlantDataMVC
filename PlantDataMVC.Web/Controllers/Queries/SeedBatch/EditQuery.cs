using Framework.Web.Views;
using PlantDataMVC.UICore.Models.ViewModels.SeedBatch;

namespace PlantDataMVC.UICore.Controllers.Queries.SeedBatch
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
using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels.SeedBatch;

namespace PlantData.Web.Mvc.Controllers.Queries.SeedBatch
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
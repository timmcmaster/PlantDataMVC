using Framework.Web.Core.Views;
using PlantDataMVC.UICore.Models.ViewModels.SaleEvent;

namespace PlantDataMVC.UICore.Controllers.Queries.SaleEvent
{
    public class DeleteQuery : IQuery<SaleEventDeleteViewModel>
    {
        public DeleteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
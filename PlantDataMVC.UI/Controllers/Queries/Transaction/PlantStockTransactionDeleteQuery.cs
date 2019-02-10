using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels.Transaction;

namespace PlantDataMVC.UI.Controllers.Queries.Transaction
{
    public class PlantStockTransactionDeleteQuery : IViewQuery<PlantStockTransactionDeleteViewModel>
    {

        public PlantStockTransactionDeleteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
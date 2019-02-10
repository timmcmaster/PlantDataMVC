using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels.Transaction;

namespace PlantDataMVC.UI.Controllers.Queries.Transaction
{
    public class DeleteQuery : IQuery<PlantStockTransactionDeleteViewModel>
    {

        public DeleteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
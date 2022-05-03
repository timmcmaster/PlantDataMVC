using Framework.Web.Core.Views;
using PlantDataMVC.UICore.Models.ViewModels.Transaction;

namespace PlantDataMVC.UICore.Controllers.Queries.Transaction
{
    public class DeleteQuery : IQuery<TransactionDeleteViewModel>
    {

        public DeleteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
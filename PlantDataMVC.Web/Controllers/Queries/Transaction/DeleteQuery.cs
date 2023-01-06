using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.Transaction;

namespace PlantDataMVC.Web.Controllers.Queries.Transaction
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
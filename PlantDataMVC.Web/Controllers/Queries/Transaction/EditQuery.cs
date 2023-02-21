using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.Transaction;

namespace PlantDataMVC.Web.Controllers.Queries.Transaction
{
    public class EditQuery : IQuery<TransactionEditViewModel>
    {
        public EditQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
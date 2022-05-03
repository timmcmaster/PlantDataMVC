using Framework.Web.Core.Views;
using PlantDataMVC.UICore.Models.ViewModels.Transaction;

namespace PlantDataMVC.UICore.Controllers.Queries.Transaction
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
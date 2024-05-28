using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels.Transaction;

namespace PlantData.Web.Mvc.Controllers.Queries.Transaction
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
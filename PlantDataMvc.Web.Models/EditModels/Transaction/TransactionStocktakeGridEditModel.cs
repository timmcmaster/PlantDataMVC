using Framework.Web.Forms;
using System.Collections.Generic;

namespace PlantDataMVC.Web.Models.EditModels.Transaction
{
    public class TransactionStocktakeGridEditModel : IForm<bool>
    {
        public IEnumerable<TransactionStocktakeListEditModel> Items { get; set; } = new List<TransactionStocktakeListEditModel>();
    }
}

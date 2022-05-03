using Framework.Web.Core.Forms;

namespace PlantDataMVC.UICore.Models.EditModels.Transaction
{
    public class TransactionDestroyEditModel : IForm<bool>
    {
        public int Id { get; set; }
    }
}

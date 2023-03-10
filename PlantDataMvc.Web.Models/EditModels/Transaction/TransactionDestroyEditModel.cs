using Framework.Web.Forms;

namespace PlantDataMVC.Web.Models.EditModels.Transaction
{
    public class TransactionDestroyEditModel : IForm<bool>
    {
        public int Id { get; set; }
    }
}

using Framework.Web.Forms;

namespace PlantData.Web.Mvc.Models.EditModels.Transaction
{
    public class TransactionDestroyEditModel : IForm<bool>
    {
        public int Id { get; set; }
    }
}

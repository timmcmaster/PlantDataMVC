using Framework.Web.Forms;
using PlantDataMVC.Domain.Entities;
using System;

namespace PlantDataMVC.UI.Models
{
    public class PlantStockTransactionCreateEditModel : IForm
    {
        public int PlantStockEntryId { get; set; }
        public PlantStockTransactionType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Quantity { get; set; }
        public int SeedTrayId { get; set; }
        public string TransactionSource { get; set; }
        public string Notes { get; set; }
    }
}

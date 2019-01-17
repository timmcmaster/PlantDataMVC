using Framework.Web.Forms;
using System;
using PlantDataMVC.DTO.Dtos;

namespace PlantDataMVC.UI.Models.EditModels
{
    public class PlantStockTransactionCreateEditModel : IForm
    {
        public int PlantStockEntryId { get; set; }
        public JournalEntryTypeDto TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Quantity { get; set; }
        public int SeedTrayId { get; set; }
        public string TransactionSource { get; set; }
        public string Notes { get; set; }
    }
}

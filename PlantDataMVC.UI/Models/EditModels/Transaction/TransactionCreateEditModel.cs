using System;
using Framework.Web.Forms;
using PlantDataMVC.DTO.Dtos;

namespace PlantDataMVC.UI.Models.EditModels.Transaction
{
    public class TransactionCreateEditModel : IForm<bool>
    {
        public int PlantStockId { get; set; }
        public JournalEntryTypeDto TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Quantity { get; set; }
        public int SeedTrayId { get; set; }
        public string TransactionSource { get; set; }
        public string Notes { get; set; }
    }
}

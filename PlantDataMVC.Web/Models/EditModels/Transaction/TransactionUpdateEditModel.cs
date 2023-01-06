using System;
using Framework.Web.Forms;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantDataMVC.UICore.Models.EditModels.Transaction
{
    public class TransactionUpdateEditModel : IForm<bool>
    {
        public int Id { get; set; }
        public int PlantStockId { get; set; }
        public JournalEntryTypeDataModel TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Quantity { get; set; }
        public int? SeedTrayId { get; set; }
        public string? TransactionSource { get; set; }
        public string? Notes { get; set; }
    }
}

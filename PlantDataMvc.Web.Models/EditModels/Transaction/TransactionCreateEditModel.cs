using System;
using Framework.Web.Forms;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantDataMVC.Web.Models.EditModels.Transaction
{
    public class TransactionCreateEditModel : IForm<bool>
    {
        public int SpeciesId { get; set; }
        public int ProductTypeId { get; set; }
        public JournalEntryTypeDataModel TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Quantity { get; set; }
        public int? SeedTrayId { get; set; }
        public string? TransactionSource { get; set; }
        public string? Notes { get; set; }
    }
}

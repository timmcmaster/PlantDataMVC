using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.Core.Domain.BusinessObjects;

namespace PlantDataMVC.UI.Models
{
    public class PlantStockTransactionCreateEditModel
    {
        public int PlantStockEntryId { get; set; }
        public int TransactionTypeId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Quantity { get; set; }
        public int SeedTrayId { get; set; }
        public string TransactionSource { get; set; }
        public string Notes { get; set; }
    }
}

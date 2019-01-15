﻿using PlantDataMVC.DTO.Entities;
using Framework.Web.Forms;
using System;

namespace PlantDataMVC.UI.Models.EditModels
{
    public class PlantStockTransactionUpdateEditModel : IForm
    {
        public int Id { get; set; }
        public int PlantStockEntryId { get; set; }
        public JournalEntryTypeDTO TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Quantity { get; set; }
        public int SeedTrayId { get; set; }
        public string TransactionSource { get; set; }
        public string Notes { get; set; }
    }
}

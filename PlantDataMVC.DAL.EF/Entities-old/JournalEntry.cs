//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlantDataMVC.DAL.EF.Entities_old
{
    using System;
    using System.Collections.Generic;
    
    public partial class JournalEntry
    {
        public int Id { get; set; }
        public int PlantStockId { get; set; }
        public int Quantity { get; set; }
        public int JournalEntryTypeId { get; set; }
        public System.DateTime TransactionDate { get; set; }
        public string Source { get; set; }
        public Nullable<int> SeedTrayId { get; set; }
        public string Notes { get; set; }
    
        internal virtual PlantStock PlantStock { get; set; }
        internal virtual SeedTray SeedTray { get; set; }
        internal virtual JournalEntryType JournalEntryType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMvc3.DAL.Interfaces;

namespace PlantDataMvc3.DAL.Entities
{
    /// <summary>
    /// This class is the class for JournalEntry objects passed outside the DAL.
    /// Other implementations are mapped to an object of this type.
    /// </summary>
    public class JournalEntry : IJournalEntry
    {
        public int Id { get; set; }
        public int PlantStockId { get; set; }
        public int Quantity { get; set; }
        public int JournalEntryTypeId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Source { get; set; }
        public Nullable<int> SeedTrayId { get; set; }
        public string Notes { get; set; }

        public virtual JournalEntryType JournalEntryType { get; set; }
        public virtual IList<SeedTray> SeedTrays { get; set; }
        public virtual IList<PlantStock> PlantStock { get; set; }
    }
}

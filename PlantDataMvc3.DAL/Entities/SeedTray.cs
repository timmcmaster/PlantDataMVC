using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMvc3.DAL.Interfaces;

namespace PlantDataMvc3.DAL.Entities
{
    /// <summary>
    /// This class is the class for xxxx objects passed outside the DAL.
    /// Other implementations are mapped to an object of this type.
    /// </summary>
    public class SeedTray : ISeedTray
    {
        public SeedTray()
        {
            JournalEntries = new List<JournalEntry>();
        }

        public int Id { get; set; }
        public int SeedBatchId { get; set; }
        public DateTime DatePlanted { get; set; }
        public string Treatment { get; set; }
        public bool ThrownOut { get; set; }

        public virtual IList<JournalEntry> JournalEntries { get; set; }
        public virtual SeedBatch SeedBatch { get; set; }
    }
}

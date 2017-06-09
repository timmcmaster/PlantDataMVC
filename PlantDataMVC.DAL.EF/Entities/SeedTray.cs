// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.6
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace PlantDataMVC.DAL.EF.Entities
{

    // SeedTray
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.31.1.0")]
    public partial class SeedTray
    {
        public int Id { get; set; } // Id (Primary key)
        public int SeedBatchId { get; set; } // SeedBatchId
        public System.DateTime DatePlanted { get; set; } // DatePlanted
        public string Treatment { get; set; } // Treatment (length: 50)
        public bool ThrownOut { get; set; } // ThrownOut

        // Reverse navigation

        /// <summary>
        /// Child JournalEntries where [JournalEntry].[SeedTrayId] point to this entity (FK_Transactions_SeedTray)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<JournalEntry> JournalEntries { get; set; } // JournalEntry.FK_Transactions_SeedTray

        // Foreign keys

        /// <summary>
        /// Parent SeedBatch pointed by [SeedTray].([SeedBatchId]) (FK_SeedTray_SeedBatch)
        /// </summary>
        public virtual SeedBatch SeedBatch { get; set; } // FK_SeedTray_SeedBatch

        public SeedTray()
        {
            JournalEntries = new System.Collections.Generic.List<JournalEntry>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

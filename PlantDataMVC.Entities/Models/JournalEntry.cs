// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable EmptyNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.7
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace PlantDataMVC.Entities.Models
{

    // JournalEntry
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class JournalEntry
    {
        public override int Id { get; set; } // Id (Primary key)
        public int PlantStockId { get; set; } // PlantStockId
        public int Quantity { get; set; } // Quantity
        public int JournalEntryTypeId { get; set; } // JournalEntryTypeId
        public System.DateTime TransactionDate { get; set; } // TransactionDate
        public string Source { get; set; } // Source (length: 50)
        public int? SeedTrayId { get; set; } // SeedTrayId
        public string Notes { get; set; } // Notes (length: 50)

        // Foreign keys

        /// <summary>
        /// Parent JournalEntryType pointed by [JournalEntry].([JournalEntryTypeId]) (FK_Transactions_TransactionType)
        /// </summary>
        public virtual JournalEntryType JournalEntryType { get; set; } // FK_Transactions_TransactionType

        /// <summary>
        /// Parent PlantStock pointed by [JournalEntry].([PlantStockId]) (FK_Transactions_PlantStock)
        /// </summary>
        public virtual PlantStock PlantStock { get; set; } // FK_Transactions_PlantStock

        /// <summary>
        /// Parent SeedTray pointed by [JournalEntry].([SeedTrayId]) (FK_Transactions_SeedTray)
        /// </summary>
        public virtual SeedTray SeedTray { get; set; } // FK_Transactions_SeedTray

        public JournalEntry()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

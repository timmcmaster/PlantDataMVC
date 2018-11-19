// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
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

    // PlantStock
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.31.1.0")]
    public partial class PlantStock
    {
        public override int Id { get; set; } // Id (Primary key)
        public int SpeciesId { get; set; } // SpeciesId
        public int ProductTypeId { get; set; } // ProductTypeId
        public int QuantityInStock { get; set; } // QuantityInStock

        // Reverse navigation

        /// <summary>
        /// Child JournalEntries where [JournalEntry].[PlantStockId] point to this entity (FK_Transactions_PlantStock)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<JournalEntry> JournalEntries { get; set; } // JournalEntry.FK_Transactions_PlantStock

        // Foreign keys

        /// <summary>
        /// Parent ProductType pointed by [PlantStock].([ProductTypeId]) (FK_PlantStock_ProductType)
        /// </summary>
        public virtual ProductType ProductType { get; set; } // FK_PlantStock_ProductType
        /// <summary>
        /// Parent Species pointed by [PlantStock].([SpeciesId]) (FK_PlantStock_Species)
        /// </summary>
        public virtual Species Species { get; set; } // FK_PlantStock_Species

        public PlantStock()
        {
            JournalEntries = new System.Collections.Generic.List<JournalEntry>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

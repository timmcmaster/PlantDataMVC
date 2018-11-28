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

    // SeedBatch
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class SeedBatch
    {
        public override int Id { get; set; } // Id (Primary key)
        public int SpeciesId { get; set; } // SpeciesId
        public System.DateTime DateCollected { get; set; } // DateCollected
        public string Location { get; set; } // Location (length: 30)
        public string Notes { get; set; } // Notes (length: 200)
        public int? SiteId { get; set; } // SiteId

        // Reverse navigation

        /// <summary>
        /// Child SeedTrays where [SeedTray].[SeedBatchId] point to this entity (FK_SeedTray_SeedBatch)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<SeedTray> SeedTrays { get; set; } // SeedTray.FK_SeedTray_SeedBatch

        // Foreign keys

        /// <summary>
        /// Parent Site pointed by [SeedBatch].([SiteId]) (FK_SeedBatch_Site)
        /// </summary>
        public virtual Site Site { get; set; } // FK_SeedBatch_Site

        /// <summary>
        /// Parent Species pointed by [SeedBatch].([SpeciesId]) (FK_SeedBatch_Species)
        /// </summary>
        public virtual Species Species { get; set; } // FK_SeedBatch_Species

        public SeedBatch()
        {
            SeedTrays = new System.Collections.Generic.List<SeedTray>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

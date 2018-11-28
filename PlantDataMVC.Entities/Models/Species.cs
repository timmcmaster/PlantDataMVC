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

    // Species
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class Species
    {
        public override int Id { get; set; } // Id (Primary key)
        public int GenusId { get; set; } // GenusId
        public string SpecificName { get; set; } // SpecificName (length: 30)
        public string CommonName { get; set; } // CommonName (length: 50)
        public string Description { get; set; } // Description (length: 200)
        public int? PropagationTime { get; set; } // PropagationTime
        public bool Native { get; set; } // Native

        // Reverse navigation

        /// <summary>
        /// Child PlantStocks where [PlantStock].[SpeciesId] point to this entity (FK_PlantStock_Species)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<PlantStock> PlantStocks { get; set; } // PlantStock.FK_PlantStock_Species
        /// <summary>
        /// Child SeedBatches where [SeedBatch].[SpeciesId] point to this entity (FK_SeedBatch_Species)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<SeedBatch> SeedBatches { get; set; } // SeedBatch.FK_SeedBatch_Species

        // Foreign keys

        /// <summary>
        /// Parent Genus pointed by [Species].([GenusId]) (FK_Species_Genus)
        /// </summary>
        public virtual Genus Genus { get; set; } // FK_Species_Genus

        public Species()
        {
            PlantStocks = new System.Collections.Generic.List<PlantStock>();
            SeedBatches = new System.Collections.Generic.List<SeedBatch>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

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

    // Site
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.31.1.0")]
    public partial class Site
    {
        public int Id { get; set; } // Id (Primary key)
        public string SiteName { get; set; } // SiteName (length: 50)
        public string Suburb { get; set; } // Suburb (length: 50)
        public decimal? Latitude { get; set; } // Latitude
        public decimal? Longitude { get; set; } // Longitude

        // Reverse navigation

        /// <summary>
        /// Child SeedBatches where [SeedBatch].[SiteId] point to this entity (FK_SeedBatch_Site)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<SeedBatch> SeedBatches { get; set; } // SeedBatch.FK_SeedBatch_Site

        public Site()
        {
            SeedBatches = new System.Collections.Generic.List<SeedBatch>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>

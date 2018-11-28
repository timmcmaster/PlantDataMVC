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


namespace PlantDataMVC.Entities.Configuration
{
    using PlantDataMVC.Entities.Context;
    using PlantDataMVC.Entities.Models;

    // Site
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class SiteConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Site>
    {
        public SiteConfiguration()
            : this("dbo")
        {
        }

        public SiteConfiguration(string schema)
        {
            ToTable("Site", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.SiteName).HasColumnName(@"SiteName").HasColumnType("nvarchar").IsOptional().HasMaxLength(50);
            Property(x => x.Suburb).HasColumnName(@"Suburb").HasColumnType("nvarchar").IsOptional().HasMaxLength(50);
            Property(x => x.Latitude).HasColumnName(@"Latitude").HasColumnType("decimal").IsOptional().HasPrecision(8,5);
            Property(x => x.Longitude).HasColumnName(@"Longitude").HasColumnType("decimal").IsOptional().HasPrecision(8,5);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>

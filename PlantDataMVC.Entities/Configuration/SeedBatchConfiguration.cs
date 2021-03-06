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

    // SeedBatch
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class SeedBatchConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<SeedBatch>
    {
        public SeedBatchConfiguration()
            : this("dbo")
        {
        }

        public SeedBatchConfiguration(string schema)
        {
            ToTable("SeedBatch", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.SpeciesId).HasColumnName(@"SpeciesId").HasColumnType("int").IsRequired();
            Property(x => x.DateCollected).HasColumnName(@"DateCollected").HasColumnType("date").IsRequired();
            Property(x => x.Location).HasColumnName(@"Location").HasColumnType("nvarchar").IsOptional().HasMaxLength(30);
            Property(x => x.Notes).HasColumnName(@"Notes").HasColumnType("nvarchar").IsOptional().HasMaxLength(200);
            Property(x => x.SiteId).HasColumnName(@"SiteId").HasColumnType("int").IsOptional();

            // Foreign keys
            HasOptional(a => a.Site).WithMany(b => b.SeedBatches).HasForeignKey(c => c.SiteId).WillCascadeOnDelete(false); // FK_SeedBatch_Site
            HasRequired(a => a.Species).WithMany(b => b.SeedBatches).HasForeignKey(c => c.SpeciesId).WillCascadeOnDelete(false); // FK_SeedBatch_Species
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>

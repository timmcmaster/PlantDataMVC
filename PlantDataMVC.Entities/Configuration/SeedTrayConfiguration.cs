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

using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Entities.Configuration
{
    using PlantDataMVC.Entities.Context;
    using PlantDataMVC.Entities.Models;

    // SeedTray
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class SeedTrayConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<SeedTray>
    {
        public SeedTrayConfiguration()
            : this("dbo")
        {
        }

        public SeedTrayConfiguration(string schema)
        {
            ToTable("SeedTray", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.SeedBatchId).HasColumnName(@"SeedBatchId").HasColumnType("int").IsRequired();
            Property(x => x.DatePlanted).HasColumnName(@"DatePlanted").HasColumnType("date").IsRequired();
            Property(x => x.Treatment).HasColumnName(@"Treatment").HasColumnType("nvarchar").IsOptional().HasMaxLength(50);
            Property(x => x.ThrownOut).HasColumnName(@"ThrownOut").HasColumnType("bit").IsRequired();

            // Foreign keys
            HasRequired(a => a.SeedBatch).WithMany(b => b.SeedTrays).HasForeignKey(c => c.SeedBatchId).WillCascadeOnDelete(false); // FK_SeedTray_SeedBatch
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>

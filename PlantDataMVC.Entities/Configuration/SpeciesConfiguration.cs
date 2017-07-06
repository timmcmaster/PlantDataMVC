// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.5
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace PlantDataMVC.Entities.Configuration
{
    using PlantDataMVC.Entities.Context;
    using PlantDataMVC.Entities.Models;

    // Species
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.31.1.0")]
    public partial class SpeciesConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Species>
    {
        public SpeciesConfiguration()
            : this("dbo")
        {
        }

        public SpeciesConfiguration(string schema)
        {
            ToTable("Species", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.GenusId).HasColumnName(@"GenusId").HasColumnType("int").IsRequired();
            Property(x => x.LatinName).HasColumnName(@"LatinName").HasColumnType("nvarchar").IsRequired().HasMaxLength(30);
            Property(x => x.CommonName).HasColumnName(@"CommonName").HasColumnType("nvarchar").IsOptional().HasMaxLength(50);
            Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar").IsOptional().HasMaxLength(200);
            Property(x => x.PropagationTime).HasColumnName(@"PropagationTime").HasColumnType("int").IsOptional();
            Property(x => x.Native).HasColumnName(@"Native").HasColumnType("bit").IsRequired();

            // Foreign keys
            HasRequired(a => a.Genus).WithMany(b => b.Species).HasForeignKey(c => c.GenusId).WillCascadeOnDelete(false); // FK_Species_Genus
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>

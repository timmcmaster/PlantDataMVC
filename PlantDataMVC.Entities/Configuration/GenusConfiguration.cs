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

    // Genus
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class GenusConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Genus>
    {
        public GenusConfiguration()
            : this("dbo")
        {
        }

        public GenusConfiguration(string schema)
        {
            ToTable("Genus", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.LatinName).HasColumnName(@"LatinName").HasColumnType("nvarchar").IsRequired().HasMaxLength(30);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>

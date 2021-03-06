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

    // PlantStock
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.2.0")]
    public partial class PlantStockConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<PlantStock>
    {
        public PlantStockConfiguration()
            : this("dbo")
        {
        }

        public PlantStockConfiguration(string schema)
        {
            ToTable("PlantStock", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.SpeciesId).HasColumnName(@"SpeciesId").HasColumnType("int").IsRequired();
            Property(x => x.ProductTypeId).HasColumnName(@"ProductTypeId").HasColumnType("int").IsRequired();
            Property(x => x.QuantityInStock).HasColumnName(@"QuantityInStock").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.ProductType).WithMany(b => b.PlantStocks).HasForeignKey(c => c.ProductTypeId).WillCascadeOnDelete(false); // FK_PlantStock_ProductType
            HasRequired(a => a.Species).WithMany(b => b.PlantStocks).HasForeignKey(c => c.SpeciesId).WillCascadeOnDelete(false); // FK_PlantStock_Species
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>

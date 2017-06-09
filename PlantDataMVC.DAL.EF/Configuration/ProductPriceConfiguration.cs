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


namespace PlantDataMVC.DAL.EF.Configuration
{
    using PlantDataMVC.DAL.EF.Context;
    using PlantDataMVC.DAL.EF.Entities;

    // ProductPrice
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.31.1.0")]
    public partial class ProductPriceConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ProductPrice>
    {
        public ProductPriceConfiguration()
            : this("dbo")
        {
        }

        public ProductPriceConfiguration(string schema)
        {
            ToTable("ProductPrice", schema);
            HasKey(x => new { x.PriceListTypeId, x.ProductTypeId, x.DateEffective });

            Property(x => x.PriceListTypeId).HasColumnName(@"PriceListTypeId").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.ProductTypeId).HasColumnName(@"ProductTypeId").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Price).HasColumnName(@"Price").HasColumnType("decimal").IsRequired().HasPrecision(18,2);
            Property(x => x.DateEffective).HasColumnName(@"DateEffective").HasColumnType("date").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);

            // Foreign keys
            HasRequired(a => a.PriceListType).WithMany(b => b.ProductPrices).HasForeignKey(c => c.PriceListTypeId).WillCascadeOnDelete(false); // FK_ProductPrices_PriceListType
            HasRequired(a => a.ProductType).WithMany(b => b.ProductPrices).HasForeignKey(c => c.ProductTypeId).WillCascadeOnDelete(false); // FK_ProductPrices_ProductType
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>

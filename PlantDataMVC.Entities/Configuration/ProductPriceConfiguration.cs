using PlantDataMVC.Entities.Context;
using PlantDataMVC.Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;


namespace PlantDataMVC.Entities.Configuration
{
    public class ProductPriceConfiguration : EntityTypeConfiguration<ProductPrice>
    {
        public ProductPriceConfiguration() : this("dbo")
        {
        }

        public ProductPriceConfiguration(string schema)
        {
            // Primary key 
            this.HasKey(x => new { x.PriceListTypeId, x.ProductTypeId, x.DateEffective });

            // Properties
            this.Property(x => x.PriceListTypeId).IsRequired();
            this.Property(x => x.ProductTypeId).IsRequired();
            this.Property(x => x.Price).IsRequired().HasPrecision(18, 2);
            this.Property(x => x.DateEffective).IsRequired();

            // Ignore 

            // Table & column mappings

            this.ToTable("ProductPrice", schema);

            this.Property(x => x.PriceListTypeId).HasColumnName(@"PriceListTypeId").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.Property(x => x.ProductTypeId).HasColumnName(@"ProductTypeId").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.Property(x => x.Price).HasColumnName(@"Price").HasColumnType("decimal");
            this.Property(x => x.DateEffective).HasColumnName(@"DateEffective").HasColumnType("date").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Foreign keys
            this.HasRequired(a => a.PriceListType).WithMany(b => b.ProductPrices).HasForeignKey(c => c.PriceListTypeId).WillCascadeOnDelete(false); // FK_ProductPrices_PriceListType
            this.HasRequired(a => a.ProductType).WithMany(b => b.ProductPrices).HasForeignKey(c => c.ProductTypeId).WillCascadeOnDelete(false); // FK_ProductPrices_ProductType
        }
    }

}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantDataMVC.Entities.EntityModels;

namespace PlantDataMVC.Entities.Configuration
{
    public class ProductPriceConfiguration : IEntityTypeConfiguration<ProductPriceEntityModel>
    {
        private string _schema;

        public ProductPriceConfiguration() : this("dbo")
        {
        }

        public ProductPriceConfiguration(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<ProductPriceEntityModel> builder)
        {
            // Primary key 
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.PriceListTypeId).IsRequired();
            builder.Property(x => x.ProductTypeId).IsRequired();
            builder.Property(x => x.Price).IsRequired();//.HasPrecision(18, 2);
            builder.Property(x => x.DateEffective).IsRequired();

            // Ignore 

            // Table & column mappings
            builder.ToTable("ProductPrice", _schema);
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").UseIdentityColumn();
            builder.Property(x => x.PriceListTypeId).HasColumnName(@"PriceListTypeId").HasColumnType("int"); //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            builder.Property(x => x.ProductTypeId).HasColumnName(@"ProductTypeId").HasColumnType("int"); //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            builder.Property(x => x.Price).HasColumnName(@"Price").HasColumnType("decimal");
            builder.Property(x => x.DateEffective).HasColumnName(@"DateEffective").HasColumnType("date"); //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Unique key
            builder.HasAlternateKey(x => new { x.PriceListTypeId, x.ProductTypeId, x.DateEffective }).HasName("AK_ProductPrice_ProductType_PriceListType_Date");

            // Foreign keys
            builder.HasOne(a => a.PriceListType).WithMany(b => b.ProductPrices).HasForeignKey(c => c.PriceListTypeId).OnDelete(DeleteBehavior.NoAction); // FK_ProductPrices_PriceListType
            builder.HasOne(a => a.ProductType).WithMany(b => b.ProductPrices).HasForeignKey(c => c.ProductTypeId).OnDelete(DeleteBehavior.NoAction); // FK_ProductPrices_ProductType
        }
    }

}

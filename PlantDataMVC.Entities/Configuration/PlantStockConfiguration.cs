using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantDataMVC.Entities.Models;


namespace PlantDataMVC.Entities.Configuration
{
    // PlantStock
    public class PlantStockConfiguration : IEntityTypeConfiguration<PlantStock>
    {
        private string _schema;

        public PlantStockConfiguration(): this("dbo")
        {
        }

        public PlantStockConfiguration(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<PlantStock> builder)
        {
            // Primary key 
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.SpeciesId).IsRequired();
            builder.Property(x => x.ProductTypeId).IsRequired();
            builder.Property(x => x.QuantityInStock).IsRequired();

            // Ignore 

            // Table & column mappings
            builder.ToTable("PlantStock", _schema);

            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").UseIdentityColumn();
            builder.Property(x => x.SpeciesId).HasColumnName(@"SpeciesId").HasColumnType("int");
            builder.Property(x => x.ProductTypeId).HasColumnName(@"ProductTypeId").HasColumnType("int");
            builder.Property(x => x.QuantityInStock).HasColumnName(@"QuantityInStock").HasColumnType("int");

            // Foreign keys
            builder.HasOne(a => a.ProductType).WithMany(b => b.PlantStocks).HasForeignKey(c => c.ProductTypeId).OnDelete(DeleteBehavior.NoAction); // FK_PlantStock_ProductType
            builder.HasOne(a => a.Species).WithMany(b => b.PlantStocks).HasForeignKey(c => c.SpeciesId).OnDelete(DeleteBehavior.NoAction); // FK_PlantStock_Species
        }
    }

}
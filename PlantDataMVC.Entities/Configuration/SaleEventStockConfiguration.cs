using Interfaces.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantDataMVC.Entities.EntityModels;

namespace PlantDataMVC.Entities.Configuration
{
    public class SaleEventStockConfiguration : IEntityTypeConfiguration<SaleEventStockEntityModel>
    {
        private string _schema;

        public SaleEventStockConfiguration()
            : this("dbo")
        {
        }

        public SaleEventStockConfiguration(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<SaleEventStockEntityModel> builder)
        {
            // Primary key 
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.SaleEventId).IsRequired();
            builder.Property(x => x.SpeciesId).IsRequired();
            builder.Property(x => x.ProductTypeId).IsRequired();
            builder.Property(x => x.Quantity);

            // Ignore 

            // Table & column mappings
            builder.ToTable("SaleEventStock", _schema);

            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").UseIdentityColumn();
            builder.Property(x => x.SaleEventId).HasColumnName("SaleEventId").HasColumnType("int");
            builder.Property(x => x.SpeciesId).HasColumnName("SpeciesId").HasColumnType("int");
            builder.Property(x => x.ProductTypeId).HasColumnName("ProductTypeId").HasColumnType("int");
            builder.Property(x => x.Quantity).HasColumnName("Quantity").HasColumnType("int");


            builder.HasOne(d => d.SaleEvent).WithMany(p => p.SaleEventStock)
                .HasForeignKey(d => d.SaleEventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleEventStock_SaleEvent");
        }
    }

}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantDataMVC.Entities.EntityModels;

namespace PlantDataMVC.Entities.Configuration
{
    public class SaleEventConfiguration : IEntityTypeConfiguration<SaleEventEntityModel>
    {
        private string _schema;

        public SaleEventConfiguration()
            : this("dbo")
        {
        }

        public SaleEventConfiguration(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<SaleEventEntityModel> builder)
        {
            // Primary key 
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(30);
            builder.Property(x => x.SaleDate);
            builder.Property(x => x.Location).HasMaxLength(30);

            // Ignore 

            // Table & column mappings
            builder.ToTable("SaleEvent", _schema);

            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar");
            builder.Property(x => x.SaleDate).HasColumnName("SaleDate").HasColumnType("date");
            builder.Property(x => x.Location).HasColumnName("Location").HasColumnType("nvarchar");
        }
    }

}

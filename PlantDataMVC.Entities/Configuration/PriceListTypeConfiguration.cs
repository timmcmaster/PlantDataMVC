using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantDataMVC.Entities.EntityModels;

namespace PlantDataMVC.Entities.Configuration
{
    // PriceListType
    public class PriceListTypeConfiguration : IEntityTypeConfiguration<PriceListTypeEntityModel>
    {
        private string _schema;

        public PriceListTypeConfiguration() : this("dbo")
        {
        }

        public PriceListTypeConfiguration(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<PriceListTypeEntityModel> builder)
        {
            // Primary key 
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Kind).IsRequired().HasMaxLength(1);

            // Ignore 

            // Table & column mappings
            builder.ToTable("PriceListType", _schema);
            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar");
            builder.Property(x => x.Kind).HasColumnName("Kind").HasColumnType("nvarchar");
        }
    }

}

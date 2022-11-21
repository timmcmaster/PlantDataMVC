using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantDataMVC.Entities.EntityModels;

namespace PlantDataMVC.Entities.Configuration
{
    public class SiteConfiguration : IEntityTypeConfiguration<SiteEntityModel>
    {
        private string _schema;

        public SiteConfiguration()
            : this("dbo")
        {
        }

        public SiteConfiguration(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<SiteEntityModel> builder)
        {
            // Primary key 
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.SiteName).HasMaxLength(50);
            builder.Property(x => x.Suburb).HasMaxLength(50);
            builder.Property(x => x.Latitude);//.HasPrecision(8, 5);
            builder.Property(x => x.Longitude);//.HasPrecision(8, 5);

            // Ignore 

            // Table & column mappings
            builder.ToTable("Site", _schema);

            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").UseIdentityColumn();
            builder.Property(x => x.SiteName).HasColumnName("SiteName").HasColumnType("nvarchar");
            builder.Property(x => x.Suburb).HasColumnName("Suburb").HasColumnType("nvarchar");
            builder.Property(x => x.Latitude).HasColumnName("Latitude").HasColumnType("decimal");
            builder.Property(x => x.Longitude).HasColumnName("Longitude").HasColumnType("decimal");
        }
    }

}

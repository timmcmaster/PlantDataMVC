using PlantDataMVC.Entities.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PlantDataMVC.Entities.Configuration
{
    public class SiteConfiguration : EntityTypeConfiguration<Site>
    {
        public SiteConfiguration()
            : this("dbo")
        {
        }

        public SiteConfiguration(string schema)
        {
            // Primary key 
            this.HasKey(x => x.Id);

            // Properties
            this.Property(x => x.Id).IsRequired();
            this.Property(x => x.SiteName).IsOptional().HasMaxLength(50);
            this.Property(x => x.Suburb).IsOptional().HasMaxLength(50);
            this.Property(x => x.Latitude).IsOptional().HasPrecision(8, 5);
            this.Property(x => x.Longitude).IsOptional().HasPrecision(8, 5);

            // Ignore 

            // Table & column mappings
            this.ToTable("Site", schema);

            this.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.SiteName).HasColumnName("SiteName").HasColumnType("nvarchar");
            this.Property(x => x.Suburb).HasColumnName("Suburb").HasColumnType("nvarchar");
            this.Property(x => x.Latitude).HasColumnName("Latitude").HasColumnType("decimal");
            this.Property(x => x.Longitude).HasColumnName("Longitude").HasColumnType("decimal");
        }
    }

}

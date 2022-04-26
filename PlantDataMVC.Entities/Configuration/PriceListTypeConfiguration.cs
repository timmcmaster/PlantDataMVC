using PlantDataMVC.Entities.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace PlantDataMVC.Entities.Configuration
{
    // PriceListType
    public class PriceListTypeConfiguration : EntityTypeConfiguration<PriceListType>
    {
        public PriceListTypeConfiguration() : this("dbo")
        {
        }

        public PriceListTypeConfiguration(string schema)
        {
            // Primary key 
            this.HasKey(x => x.Id);

            // Properties
            this.Property(x => x.Id).IsRequired();
            this.Property(x => x.Name).IsRequired().HasMaxLength(50);
            this.Property(x => x.Kind).IsRequired().HasMaxLength(1);

            // Ignore 

            // Table & column mappings
            this.ToTable("PriceListType", schema);
            this.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar");
            this.Property(x => x.Kind).HasColumnName("Kind").HasColumnType("nvarchar");
        }
    }

}

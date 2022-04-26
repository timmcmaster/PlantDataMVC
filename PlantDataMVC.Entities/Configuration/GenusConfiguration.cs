using PlantDataMVC.Entities.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PlantDataMVC.Entities.Configuration
{

    // Genus
    public class GenusConfiguration : EntityTypeConfiguration<Genus>
    {
        public GenusConfiguration() : this("dbo")
        {
        }

        public GenusConfiguration(string schema)
        {
            // Primary key 
            this.HasKey(x => x.Id);

            // Properties
            this.Property(x => x.Id).IsRequired();
            this.Property(x => x.LatinName).IsRequired().HasMaxLength(30);

            // Ignore 

            // Table & column mappings
            this.ToTable("Genus", schema);
            this.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.LatinName).HasColumnName("LatinName").HasColumnType("nvarchar");
        }
    }

}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantDataMVC.Entities.Models;

namespace PlantDataMVC.Entities.Configuration
{

    // Genus
    public class GenusConfiguration : IEntityTypeConfiguration<Genus>
    {
        private string _schema; 

        public GenusConfiguration() : this("dbo")
        {
        }

        public GenusConfiguration(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<Genus> builder)
        {
            // Primary key 
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.LatinName).IsRequired().HasMaxLength(30);

            // Ignore 

            // Table & column mappings
            builder.ToTable("Genus", _schema);
            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").UseIdentityColumn();
            builder.Property(x => x.LatinName).HasColumnName("LatinName").HasColumnType("nvarchar");
        }
    }

}

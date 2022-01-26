
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;


namespace PlantDataMVC.Entities.Configuration
{
    using PlantDataMVC.Entities.Context;
    using PlantDataMVC.Entities.Models;

    // JournalEntryType
    public class JournalEntryTypeConfiguration : EntityTypeConfiguration<JournalEntryType>
    {
        public JournalEntryTypeConfiguration() : this("dbo")
        {
        }

        public JournalEntryTypeConfiguration(string schema)
        {
            // Primary key 
            this.HasKey(x => x.Id);

            // Properties
            this.Property(x => x.Id).IsRequired();
            this.Property(x => x.Name).IsRequired().HasMaxLength(50);
            this.Property(x => x.Effect).IsRequired();

            // Ignore 

            // Table & column mappings
            this.ToTable("JournalEntryType", schema);
            this.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar");
            this.Property(x => x.Effect).HasColumnName("Effect").HasColumnType("int");
        }
    }

}


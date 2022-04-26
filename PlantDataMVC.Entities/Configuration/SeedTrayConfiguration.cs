using PlantDataMVC.Entities.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PlantDataMVC.Entities.Configuration
{
    public class SeedTrayConfiguration : EntityTypeConfiguration<SeedTray>
    {
        public SeedTrayConfiguration() : this("dbo")
        {
        }

        public SeedTrayConfiguration(string schema)
        {
            // Primary key 
            this.HasKey(x => x.Id);

            // Properties
            this.Property(x => x.Id).IsRequired();
            this.Property(x => x.SeedBatchId).IsRequired();
            this.Property(x => x.DatePlanted).IsRequired();
            this.Property(x => x.Treatment).IsOptional().HasMaxLength(50);
            this.Property(x => x.ThrownOut).IsRequired();

            // Ignore 

            // Table & column mappings
            this.ToTable("SeedTray", schema);

            this.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.SeedBatchId).HasColumnName(@"SeedBatchId").HasColumnType("int");
            this.Property(x => x.DatePlanted).HasColumnName(@"DatePlanted").HasColumnType("date");
            this.Property(x => x.Treatment).HasColumnName(@"Treatment").HasColumnType("nvarchar");
            this.Property(x => x.ThrownOut).HasColumnName(@"ThrownOut").HasColumnType("bit");

            // Foreign keys
            HasRequired(a => a.SeedBatch).WithMany(b => b.SeedTrays).HasForeignKey(c => c.SeedBatchId).WillCascadeOnDelete(false); // FK_SeedTray_SeedBatch
        }
    }

}

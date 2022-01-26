using PlantDataMVC.Entities.Context;
using PlantDataMVC.Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantDataMVC.Entities.Configuration
{
    public class SeedBatchConfiguration : EntityTypeConfiguration<SeedBatch>
    {
        public SeedBatchConfiguration() : this("dbo")
        {
        }

        public SeedBatchConfiguration(string schema)
        {
            // Primary key 
            this.HasKey(x => x.Id);

            // Properties
            this.Property(x => x.Id).IsRequired();
            this.Property(x => x.SpeciesId).IsRequired();
            this.Property(x => x.DateCollected).IsRequired();
            this.Property(x => x.Location).IsOptional().HasMaxLength(30);
            this.Property(x => x.Notes).IsOptional().HasMaxLength(200);
            this.Property(x => x.SiteId).IsOptional();

            // Ignore 

            // Table & column mappings
            this.ToTable("SeedBatch", schema);
            this.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.SpeciesId).HasColumnName(@"SpeciesId").HasColumnType("int");
            this.Property(x => x.DateCollected).HasColumnName(@"DateCollected").HasColumnType("date");
            this.Property(x => x.Location).HasColumnName(@"Location").HasColumnType("nvarchar");
            this.Property(x => x.Notes).HasColumnName(@"Notes").HasColumnType("nvarchar");
            this.Property(x => x.SiteId).HasColumnName(@"SiteId").HasColumnType("int");

            // Foreign keys
            this.HasOptional(a => a.Site).WithMany(b => b.SeedBatches).HasForeignKey(c => c.SiteId).WillCascadeOnDelete(false); // FK_SeedBatch_Site
            this.HasRequired(a => a.Species).WithMany(b => b.SeedBatches).HasForeignKey(c => c.SpeciesId).WillCascadeOnDelete(false); // FK_SeedBatch_Species
        }
    }

}

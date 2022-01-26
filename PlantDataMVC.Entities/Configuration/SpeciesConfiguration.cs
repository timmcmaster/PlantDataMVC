using PlantDataMVC.Entities.Context;
using PlantDataMVC.Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantDataMVC.Entities.Configuration
{
    public class SpeciesConfiguration : EntityTypeConfiguration<Species>
    {
        public SpeciesConfiguration() : this("dbo")
        {
        }

        public SpeciesConfiguration(string schema)
        {
            // Primary key 
            this.HasKey(x => x.Id);

            // Properties
            this.Property(x => x.Id).IsRequired();
            this.Property(x => x.GenusId).IsRequired();
            this.Property(x => x.SpecificName).IsRequired().HasMaxLength(30);
            this.Property(x => x.CommonName).IsOptional().HasMaxLength(50);
            this.Property(x => x.Description).IsOptional().HasMaxLength(200);
            this.Property(x => x.PropagationTime).IsOptional();
            this.Property(x => x.Native).IsRequired();

            // Ignore 

            // Table & column mappings
            this.ToTable("Species", schema);

            this.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.GenusId).HasColumnName(@"GenusId").HasColumnType("int");
            this.Property(x => x.SpecificName).HasColumnName(@"SpecificName").HasColumnType("nvarchar");
            this.Property(x => x.CommonName).HasColumnName(@"CommonName").HasColumnType("nvarchar");
            this.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar");
            this.Property(x => x.PropagationTime).HasColumnName(@"PropagationTime").HasColumnType("int");
            this.Property(x => x.Native).HasColumnName(@"Native").HasColumnType("bit");

            // Foreign keys
            this.HasRequired(a => a.Genus).WithMany(b => b.Species).HasForeignKey(c => c.GenusId).WillCascadeOnDelete(false); // FK_Species_Genus
        }
    }

}

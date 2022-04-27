using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantDataMVC.Entities.Models;

namespace PlantDataMVC.Entities.Configuration
{
    public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
    {
        private string _schema;

        public SpeciesConfiguration() : this("dbo")
        {
        }

        public SpeciesConfiguration(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<Species> builder)
        {
            // Primary key 
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.GenusId).IsRequired();
            builder.Property(x => x.SpecificName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.CommonName).HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(200);
            builder.Property(x => x.PropagationTime);
            builder.Property(x => x.Native).IsRequired();

            // Ignore 

            // Table & column mappings
            builder.ToTable("Species", _schema);

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").UseIdentityColumn();
            builder.Property(x => x.GenusId).HasColumnName(@"GenusId").HasColumnType("int");
            builder.Property(x => x.SpecificName).HasColumnName(@"SpecificName").HasColumnType("nvarchar");
            builder.Property(x => x.CommonName).HasColumnName(@"CommonName").HasColumnType("nvarchar");
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar");
            builder.Property(x => x.PropagationTime).HasColumnName(@"PropagationTime").HasColumnType("int");
            builder.Property(x => x.Native).HasColumnName(@"Native").HasColumnType("bit");

            // Foreign keys
            builder.HasOne(a => a.Genus).WithMany(b => b.Species).HasForeignKey(c => c.GenusId).OnDelete(DeleteBehavior.NoAction); // FK_Species_Genus
        }
    }

}

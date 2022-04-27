using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantDataMVC.Entities.Models;

namespace PlantDataMVC.Entities.Configuration
{
    public class SeedTrayConfiguration : IEntityTypeConfiguration<SeedTray>
    {
        private string _schema;

        public SeedTrayConfiguration() : this("dbo")
        {
        }

        public SeedTrayConfiguration(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<SeedTray> builder)
        {
            // Primary key 
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.SeedBatchId).IsRequired();
            builder.Property(x => x.DatePlanted).IsRequired();
            builder.Property(x => x.Treatment).HasMaxLength(50);
            builder.Property(x => x.ThrownOut).IsRequired();

            // Ignore 

            // Table & column mappings
            builder.ToTable("SeedTray", _schema);

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").UseIdentityColumn();
            builder.Property(x => x.SeedBatchId).HasColumnName(@"SeedBatchId").HasColumnType("int");
            builder.Property(x => x.DatePlanted).HasColumnName(@"DatePlanted").HasColumnType("date");
            builder.Property(x => x.Treatment).HasColumnName(@"Treatment").HasColumnType("nvarchar");
            builder.Property(x => x.ThrownOut).HasColumnName(@"ThrownOut").HasColumnType("bit");

            // Foreign keys
            builder.HasOne(a => a.SeedBatch).WithMany(b => b.SeedTrays).HasForeignKey(c => c.SeedBatchId).OnDelete(DeleteBehavior.NoAction); // FK_SeedTray_SeedBatch
        }
    }

}

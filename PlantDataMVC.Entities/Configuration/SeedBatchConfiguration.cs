using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantDataMVC.Entities.EntityModels;

namespace PlantDataMVC.Entities.Configuration
{
    public class SeedBatchConfiguration : IEntityTypeConfiguration<SeedBatchEntityModel>
    {
        private string _schema;

        public SeedBatchConfiguration() : this("dbo")
        {
        }

        public SeedBatchConfiguration(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<SeedBatchEntityModel> builder)
        {
            // Primary key 
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.SpeciesId).IsRequired();
            builder.Property(x => x.DateCollected).IsRequired();
            builder.Property(x => x.Location).HasMaxLength(30);
            builder.Property(x => x.Notes).HasMaxLength(200);
            builder.Property(x => x.SiteId);
            builder.Property(x => x.Emptied).IsRequired();

            // Ignore 

            // Table & column mappings
            builder.ToTable("SeedBatch", _schema);
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").UseIdentityColumn();
            builder.Property(x => x.SpeciesId).HasColumnName(@"SpeciesId").HasColumnType("int");
            builder.Property(x => x.DateCollected).HasColumnName(@"DateCollected").HasColumnType("date");
            builder.Property(x => x.Location).HasColumnName(@"Location").HasColumnType("nvarchar");
            builder.Property(x => x.Notes).HasColumnName(@"Notes").HasColumnType("nvarchar");
            builder.Property(x => x.SiteId).HasColumnName(@"SiteId").HasColumnType("int");
            builder.Property(x => x.Emptied).HasColumnName(@"Emptied").HasColumnType("bit");

            // Foreign keys
            builder.HasOne(a => a.Site).WithMany(b => b.SeedBatches).HasForeignKey(c => c.SiteId).OnDelete(DeleteBehavior.NoAction); // FK_SeedBatch_Site
            builder.HasOne(a => a.Species).WithMany(b => b.SeedBatches).HasForeignKey(c => c.SpeciesId).OnDelete(DeleteBehavior.NoAction); // FK_SeedBatch_Species
        }
    }

}

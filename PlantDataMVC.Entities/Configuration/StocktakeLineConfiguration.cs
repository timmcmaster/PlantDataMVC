using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantDataMVC.Entities.EntityModels;

namespace PlantDataMVC.Entities.Configuration
{
    public class StocktakeLineConfiguration : IEntityTypeConfiguration<StocktakeLineEntityModel>
    {
        private string _schema;

        public StocktakeLineConfiguration() : this("dbo")
        {
        }

        public StocktakeLineConfiguration(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<StocktakeLineEntityModel> builder)
        {
            // Primary key 
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.HeaderId).IsRequired();
            builder.Property(x => x.SpeciesId).IsRequired();
            builder.Property(x => x.ProductTypeId).IsRequired();
            builder.Property(x => x.ExpectedQuantity).IsRequired();
            builder.Property(x => x.CountedQuantity).IsRequired();
            builder.Property(x => x.Applied).IsRequired();

            // Ignore 

            // Table & column mappings
            builder.ToTable("StocktakeLine", _schema);

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").UseIdentityColumn();
            builder.Property(x => x.HeaderId).HasColumnName(@"HeaderId").HasColumnType("int");
            builder.Property(x => x.SpeciesId).HasColumnName(@"SpeciesId").HasColumnType("int");
            builder.Property(x => x.ProductTypeId).HasColumnName(@"ProductTypeId").HasColumnType("int");
            builder.Property(x => x.ExpectedQuantity).HasColumnName(@"ExpectedQuantity").HasColumnType("int");
            builder.Property(x => x.CountedQuantity).HasColumnName(@"CountedQuantity").HasColumnType("int");
            builder.Property(x => x.Applied).HasColumnName(@"Applied").HasColumnType("bit");

            // Foreign keys
            builder.HasOne(a => a.Header).WithMany(b => b.Lines)
                .HasForeignKey(c => c.HeaderId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_StocktakeLine_Stocktake_HeaderId");
        }
    }

}

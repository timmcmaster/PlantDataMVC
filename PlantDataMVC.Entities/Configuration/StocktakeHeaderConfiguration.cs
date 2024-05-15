using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantDataMVC.Entities.EntityModels;

namespace PlantDataMVC.Entities.Configuration
{
    public class StocktakeHeaderConfiguration : IEntityTypeConfiguration<StocktakeHeaderEntityModel>
    {
        private string _schema;

        public StocktakeHeaderConfiguration() : this("dbo")
        {
        }

        public StocktakeHeaderConfiguration(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<StocktakeHeaderEntityModel> builder)
        {
            // Primary key 
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Reference).IsRequired().HasMaxLength(50);
            builder.Property(x => x.StocktakeDate).IsRequired();

            // Ignore 

            // Table & column mappings
            builder.ToTable("Stocktake", _schema);

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").UseIdentityColumn();
            builder.Property(x => x.Reference).HasColumnName(@"Reference").HasColumnType("nvarchar");
            builder.Property(x => x.StocktakeDate).HasColumnName(@"StocktakeDate").HasColumnType("datetime2");
        }
    }

}

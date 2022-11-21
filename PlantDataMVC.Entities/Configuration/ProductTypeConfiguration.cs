using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantDataMVC.Entities.EntityModels;

namespace PlantDataMVC.Entities.Configuration
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductTypeEntityModel>
    {
        private string _schema;

        public ProductTypeConfiguration() : this("dbo")
        {
        }

        public ProductTypeConfiguration(string schema)
        {
            _schema = schema;
        }

        public void Configure(EntityTypeBuilder<ProductTypeEntityModel> builder)
        {
            // Primary key 
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            // Ignore 

            // Table & column mappings
            builder.ToTable("ProductType", _schema);
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar");
        }
    }
}

using PlantDataMVC.Entities.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PlantDataMVC.Entities.Configuration
{
    public class ProductTypeConfiguration : EntityTypeConfiguration<ProductType>
    {
        public ProductTypeConfiguration() : this("dbo")
        {
        }

        public ProductTypeConfiguration(string schema)
        {
            // Primary key 
            this.HasKey(x => x.Id);

            // Properties
            this.Property(x => x.Id).IsRequired();
            this.Property(x => x.Name).IsRequired().HasMaxLength(50);

            // Ignore 

            // Table & column mappings
            this.ToTable("ProductType", schema);
            this.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar");
        }
    }
}

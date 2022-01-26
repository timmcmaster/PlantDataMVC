using PlantDataMVC.Entities.Context;
using PlantDataMVC.Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;


namespace PlantDataMVC.Entities.Configuration
{
    // PlantStock
    public class PlantStockConfiguration : EntityTypeConfiguration<PlantStock>
    {
        public PlantStockConfiguration()
            : this("dbo")
        {
        }

        public PlantStockConfiguration(string schema)
        {
            // Primary key 
            this.HasKey(x => x.Id);

            // Properties
            this.Property(x => x.Id).IsRequired();
            this.Property(x => x.SpeciesId).IsRequired();
            this.Property(x => x.ProductTypeId).IsRequired();
            this.Property(x => x.QuantityInStock).IsRequired();

            // Ignore 

            // Table & column mappings
            this.ToTable("PlantStock", schema);

            this.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.SpeciesId).HasColumnName(@"SpeciesId").HasColumnType("int");
            this.Property(x => x.ProductTypeId).HasColumnName(@"ProductTypeId").HasColumnType("int");
            this.Property(x => x.QuantityInStock).HasColumnName(@"QuantityInStock").HasColumnType("int");

            // Foreign keys
            this.HasRequired(a => a.ProductType).WithMany(b => b.PlantStocks).HasForeignKey(c => c.ProductTypeId).WillCascadeOnDelete(false); // FK_PlantStock_ProductType
            this.HasRequired(a => a.Species).WithMany(b => b.PlantStocks).HasForeignKey(c => c.SpeciesId).WillCascadeOnDelete(false); // FK_PlantStock_Species
        }
    }

}
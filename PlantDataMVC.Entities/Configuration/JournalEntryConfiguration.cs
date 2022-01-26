using PlantDataMVC.Entities.Context;
using PlantDataMVC.Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;


namespace PlantDataMVC.Entities.Configuration
{
    // JournalEntry
    public class JournalEntryConfiguration : EntityTypeConfiguration<JournalEntry>
    {
        public JournalEntryConfiguration() : this("dbo")
        {
        }

        public JournalEntryConfiguration(string schema)
        {
            // Primary key 
            this.HasKey(x => x.Id);

            // Properties
            this.Property(x => x.Id).IsRequired();
            this.Property(x => x.PlantStockId).IsRequired();
            this.Property(x => x.Quantity).IsRequired();
            this.Property(x => x.JournalEntryTypeId).IsRequired();
            this.Property(x => x.TransactionDate).IsRequired();
            this.Property(x => x.Source).IsOptional().HasMaxLength(50);
            this.Property(x => x.SeedTrayId).IsOptional();
            this.Property(x => x.Notes).IsOptional().HasMaxLength(50);

            // Ignore 

            // Table & column mappings
            this.ToTable("JournalEntry", schema);

            this.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.PlantStockId).HasColumnName(@"PlantStockId").HasColumnType("int");
            this.Property(x => x.Quantity).HasColumnName(@"Quantity").HasColumnType("int");
            this.Property(x => x.JournalEntryTypeId).HasColumnName(@"JournalEntryTypeId").HasColumnType("int");
            this.Property(x => x.TransactionDate).HasColumnName(@"TransactionDate").HasColumnType("date");
            this.Property(x => x.Source).HasColumnName(@"Source").HasColumnType("nvarchar");
            this.Property(x => x.SeedTrayId).HasColumnName(@"SeedTrayId").HasColumnType("int");
            this.Property(x => x.Notes).HasColumnName(@"Notes").HasColumnType("nvarchar");

            // Foreign keys
            this.HasOptional(a => a.SeedTray).WithMany(b => b.JournalEntries).HasForeignKey(c => c.SeedTrayId).WillCascadeOnDelete(false); // FK_Transactions_SeedTray
            this.HasRequired(a => a.JournalEntryType).WithMany(b => b.JournalEntries).HasForeignKey(c => c.JournalEntryTypeId).WillCascadeOnDelete(false); // FK_Transactions_TransactionType
            this.HasRequired(a => a.PlantStock).WithMany(b => b.JournalEntries).HasForeignKey(c => c.PlantStockId).WillCascadeOnDelete(false); // FK_Transactions_PlantStock
        }
    }

}

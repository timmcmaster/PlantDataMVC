using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantDataMVC.Entities.EntityModels;


namespace PlantDataMVC.Entities.Configuration
{
    // JournalEntry
    public class JournalEntryConfiguration : IEntityTypeConfiguration<JournalEntryEntityModel>
    {
        private string _schema;

        public JournalEntryConfiguration() : this("dbo")
        {
        }

        public JournalEntryConfiguration(string schema)
        {
            _schema = schema;
        }
        public void Configure(EntityTypeBuilder<JournalEntryEntityModel> builder)
        {
            // Primary key 
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.PlantStockId).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.JournalEntryTypeId).IsRequired();
            builder.Property(x => x.TransactionDate).IsRequired();
            builder.Property(x => x.Source).HasMaxLength(50);
            builder.Property(x => x.SeedTrayId);
            builder.Property(x => x.Notes).HasMaxLength(50);

            // Ignore 

            // Table & column mappings
            builder.ToTable("JournalEntry", _schema);

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").UseIdentityColumn();
            builder.Property(x => x.PlantStockId).HasColumnName(@"PlantStockId").HasColumnType("int");
            builder.Property(x => x.Quantity).HasColumnName(@"Quantity").HasColumnType("int");
            builder.Property(x => x.JournalEntryTypeId).HasColumnName(@"JournalEntryTypeId").HasColumnType("int");
            builder.Property(x => x.TransactionDate).HasColumnName(@"TransactionDate").HasColumnType("date");
            builder.Property(x => x.Source).HasColumnName(@"Source").HasColumnType("nvarchar");
            builder.Property(x => x.SeedTrayId).HasColumnName(@"SeedTrayId").HasColumnType("int");
            builder.Property(x => x.Notes).HasColumnName(@"Notes").HasColumnType("nvarchar");

            // Foreign keys
            builder.HasOne(a => a.SeedTray).WithMany(b => b.JournalEntries).HasForeignKey(c => c.SeedTrayId).OnDelete(DeleteBehavior.NoAction); // FK_Transactions_SeedTray
            builder.HasOne(a => a.JournalEntryType).WithMany(b => b.JournalEntries).HasForeignKey(c => c.JournalEntryTypeId).OnDelete(DeleteBehavior.NoAction); // FK_Transactions_TransactionType
            builder.HasOne(a => a.PlantStock).WithMany(b => b.JournalEntries).HasForeignKey(c => c.PlantStockId).OnDelete(DeleteBehavior.NoAction); // FK_Transactions_PlantStock
        }
    }

}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantDataMVC.Entities.EntityModels;


namespace PlantDataMVC.Entities.Configuration
{
    using PlantDataMVC.Entities.EntityModels;

    // JournalEntryType
    public class JournalEntryTypeConfiguration : IEntityTypeConfiguration<JournalEntryTypeEntityModel>
    {
        private string _schema;

        public JournalEntryTypeConfiguration() : this("dbo")
        {
        }

        public JournalEntryTypeConfiguration(string schema) 
        {
            _schema = schema;

        }

        public void Configure(EntityTypeBuilder<JournalEntryTypeEntityModel> builder)
        {
            // Primary key 
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Effect).IsRequired();

            // Ignore 

            // Table & column mappings
            builder.ToTable("JournalEntryType", _schema);
            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar");
            builder.Property(x => x.Effect).HasColumnName("Effect").HasColumnType("int");
        }
    }

}


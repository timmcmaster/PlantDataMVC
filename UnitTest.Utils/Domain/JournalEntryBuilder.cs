using System;
using PlantDataMVC.Entities.EntityModels;
using UnitTest.Utils.Common;

namespace UnitTest.Utils.Domain
{
    /// <summary>
    /// Creates random data against the domain objects in the namespace <code>PlantDataMVC.Core.Domain.BusinessObjects</code>
    /// </summary>
    public class JournalEntryBuilder
    {
        // Default members
        public static readonly int DEFAULT_QUANTITY = 0;
        public static readonly string DEFAULT_NOTES = "test notes";
        public static readonly string DEFAULT_SOURCE = "Autumn plant sale";
        public static readonly DateTime DEFAULT_DATE = new DateTime(2011,5,31);


        // private members (for object properties)
        private int _id;
        private string _notes = DEFAULT_NOTES;
        private int _quantity = DEFAULT_QUANTITY;
        private JournalEntryTypeEntityModel _journalEntryType;
        private SpeciesEntityModel _species;
        private ProductTypeEntityModel _productType;
        private SeedTrayEntityModel _seedTray;
        private string _source = DEFAULT_SOURCE;
        private DateTime _transactionDate = DEFAULT_DATE;

        private JournalEntryBuilder()
        {
        }

        /// <summary>
        /// Starting point for creating plant test data
        /// </summary>
        /// <returns></returns>
        public static JournalEntryBuilder aJournalEntry()
        {
            return new JournalEntryBuilder();
        }

        public JournalEntryBuilder withNoId()
        {
            _id = 0;
            return this;
        }

        public JournalEntryBuilder withId()
        {
            _id = CommonTestData.GenerateRandomInt();
            return this;
        }

        public JournalEntryBuilder withNotes(string notes)
        {
            _notes = notes;
            return this;
        }

        public JournalEntryBuilder withQuantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }

        public JournalEntryBuilder withSource(string source)
        {
            _source = source;
            return this;
        }

        public JournalEntryBuilder withTransactionDate(DateTime transactionDate)
        {
            _transactionDate = transactionDate;
            return this;
        }

        public JournalEntryBuilder withSpecies(SpeciesEntityModel species)
        {
            _species = species;
            return this;
        }

        public JournalEntryBuilder withProductType(ProductTypeEntityModel productType)
        {
            _productType = productType;
            return this;
        }

        public JournalEntryBuilder withJournalEntryType(JournalEntryTypeEntityModel journalEntryType)
        {
            _journalEntryType = journalEntryType;
            return this;
        }

        public JournalEntryBuilder withSeedTray(SeedTrayEntityModel seedTray)
        {
            _seedTray = seedTray;
            return this;
        }

        public JournalEntryBuilder withRandomValues()
        {
            _id = CommonTestData.GenerateRandomInt();
            _quantity = CommonTestData.GenerateRandomInt();
            _source = CommonTestData.GenerateRandomString(30);
            _transactionDate = CommonTestData.GenerateRandomDateInThePast();
            _notes = CommonTestData.GenerateRandomString(100);
            return this;
        }

        public JournalEntryEntityModel Build()
        {
            return new JournalEntryEntityModel()
            {
                Id = _id,
                Notes = _notes,
                JournalEntryType = _journalEntryType,
                JournalEntryTypeId = _journalEntryType.Id,
                Species = _species,
                SpeciesId = _species.Id,
                ProductType = _productType,
                ProductTypeId = _productType.Id,
                Quantity = _quantity,
                SeedTray = _seedTray,
                SeedTrayId = (_seedTray != null) ? _seedTray.Id : (int?)null,
                Source = _source,
                TransactionDate = _transactionDate
            };
        }
    }
}
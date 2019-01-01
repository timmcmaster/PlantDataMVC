using System;
using PlantDataMVC.Entities.Models;
using UnitTest.Utils.Common;

namespace UnitTest.Utils.DAL
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
        private JournalEntryType _journalEntryType;
        private PlantStock _plantStock;
        private SeedTray _seedTray;
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
            _id = CommonTestData.GeneratRandomInt();
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

        public JournalEntryBuilder withPlantStock(PlantStock plantStock)
        {
            _plantStock = plantStock;
            return this;
        }

        public JournalEntryBuilder withJournalEntryType(JournalEntryType journalEntryType)
        {
            _journalEntryType = journalEntryType;
            return this;
        }

        public JournalEntryBuilder withSeedTray(SeedTray seedTray)
        {
            _seedTray = seedTray;
            return this;
        }

        public JournalEntryBuilder withRandomValues()
        {
            _id = CommonTestData.GeneratRandomInt();
            _quantity = CommonTestData.GeneratRandomInt();
            _source = CommonTestData.GenerateRandomString(30);
            _transactionDate = CommonTestData.GenerateRandomDateInThePast();
            _notes = CommonTestData.GenerateRandomString(100);
            return this;
        }

        public JournalEntry Build()
        {
            return new JournalEntry()
            {
                Id = _id,
                Notes = _notes,
                JournalEntryType = _journalEntryType,
                JournalEntryTypeId = _journalEntryType.Id,
                PlantStock = _plantStock,
                PlantStockId = _plantStock.Id,
                Quantity = _quantity,
                SeedTray = _seedTray,
                SeedTrayId = (_seedTray != null) ? _seedTray.Id : (int?)null,
                Source = _source,
                TransactionDate = _transactionDate
            };
        }
    }
}
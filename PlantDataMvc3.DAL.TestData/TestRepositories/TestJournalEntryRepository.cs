using PlantDataMvc3.DAL.Entities;
using PlantDataMvc3.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace PlantDataMvc3.DAL.TestData
{
    public class TestJournalEntryRepository : TestRepositoryBase<JournalEntry>, IJournalEntryRepository
    {
        public TestJournalEntryRepository()
            : base()
        { }

        public override JournalEntry CreateItem(JournalEntry requestItem)
        {
            requestItem.Id = _randomGen.Next();

            return requestItem;
        }

        public override JournalEntry SelectItem(int id)
        {
            return new JournalEntry()
            {
                Id = id,
                PlantStockId = 0,
                JournalEntryTypeId = 1,
                TransactionDate = DateTime.Today,
                Quantity = 3,
                SeedTrayId = 0,
                Source = "Market",
                Notes = ""
            };
        }

        public override JournalEntry UpdateItem(JournalEntry requestItem)
        {
            return requestItem;
        }

        public override void DeleteItem(int id)
        {
        }

        public override IList<JournalEntry> ListItems()
        {
            List<JournalEntry> transactionList = new List<JournalEntry>();
            transactionList.Add(new JournalEntry() { Id = 1, PlantStockId = 11, JournalEntryTypeId = 4, TransactionDate = new DateTime(2011, 01, 11), Quantity = 7, SeedTrayId = 0, Source = "", Notes = "" });
            transactionList.Add(new JournalEntry() { Id = 2, PlantStockId = 11, JournalEntryTypeId = 1, TransactionDate = new DateTime(2011, 01, 11), Quantity = 3, SeedTrayId = 0, Source = "", Notes = "" });
            transactionList.Add(new JournalEntry() { Id = 3, PlantStockId = 11, JournalEntryTypeId = 2, TransactionDate = new DateTime(2011, 01, 11), Quantity = 2, SeedTrayId = 0, Source = "", Notes = "" });
            transactionList.Add(new JournalEntry() { Id = 4, PlantStockId = 14, JournalEntryTypeId = 1, TransactionDate = new DateTime(2011, 01, 11), Quantity = 4, SeedTrayId = 0, Source = "", Notes = "" });

            return transactionList;
        }
    }
}

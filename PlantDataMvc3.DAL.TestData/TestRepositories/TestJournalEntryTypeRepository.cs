using PlantDataMVC.DAL.Entities;
using PlantDataMVC.DAL.Interfaces;
using System.Collections.Generic;
using System;

namespace PlantDataMVC.DAL.TestData
{
    public class TestJournalEntryTypeRepository : TestRepositoryBase<JournalEntryType>, IJournalEntryTypeRepository
    {
        public TestJournalEntryTypeRepository()
            : base()
        { }

        public override JournalEntryType CreateItem(JournalEntryType requestItem)
        {
            requestItem.Id = _randomGen.Next();

            return requestItem;
        }

        public override JournalEntryType SelectItem(int id)
        {
            return new JournalEntryType()
            {
                Id = id,
                Name = "Sale",
                Effect = -1
            };
        }

        public override JournalEntryType UpdateItem(JournalEntryType requestItem)
        {
            return requestItem;
        }

        public override void DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<JournalEntryType> ListItems()
        {
            List<JournalEntryType> transactionTypeList = new List<JournalEntryType>();
            transactionTypeList.Add(new JournalEntryType() { Id = 4, Name = "Potted Out", Effect = +1 });
            transactionTypeList.Add(new JournalEntryType() { Id = 1, Name = "Sale", Effect = -1 });
            transactionTypeList.Add(new JournalEntryType() { Id = 2, Name = "Died", Effect = -1 });
            transactionTypeList.Add(new JournalEntryType() { Id = 3, Name = "Gift Given", Effect = -1 });

            return transactionTypeList;
        }
    }
}

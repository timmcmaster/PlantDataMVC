using PlantDataMVC.Entities.EntityModels;
using UnitTest.Utils.Common;

namespace UnitTest.Utils.Domain
{
    /// <summary>
    /// Creates random data against the domain objects in the namespace <code>PlantDataMVC.Core.Domain.BusinessObjects</code>
    /// </summary>
    public class JournalEntryTypeBuilder
    {
        // Default members
        public static readonly string DEFAULT_NAME = "Potted from seed tray";
        public static readonly int DEFAULT_EFFECT = 1;

        // private members (for object properties)
        private int _id;
        private string _name = DEFAULT_NAME;
        private int _effect = DEFAULT_EFFECT;

        private JournalEntryTypeBuilder()
        {
        }

        /// <summary>
        /// Starting point for creating plant test data
        /// </summary>
        /// <returns></returns>
        public static JournalEntryTypeBuilder aJournalEntryType()
        {
            return new JournalEntryTypeBuilder();
        }

        public JournalEntryTypeBuilder withNoId()
        {
            _id = 0;
            return this;
        }

        public JournalEntryTypeBuilder withId()
        {
            _id = CommonTestData.GenerateRandomInt();
            return this;
        }

        public JournalEntryTypeBuilder withName(string name)
        {
            _name = name;
            return this;
        }

        public JournalEntryTypeBuilder withEffect(int effect)
        {
            _effect = effect;
            return this;
        }

        public JournalEntryTypeBuilder withRandomValues()
        {
            _id = CommonTestData.GenerateRandomInt();
            _name = CommonTestData.GenerateRandomAlphabetString(10);
            return this;
        }

        public JournalEntryTypeEntityModel Build()
        {
            return new JournalEntryTypeEntityModel()
            {
                Id = _id,
                Name = _name,
                Effect = _effect
            };
        }
    }
}
using PlantDataMvc3.DAL.LocalInterfaces;

namespace PlantDataMvc3.DAL.EF.Entities
{
    partial class Site : ILocalSite
    {
    }

    partial class PriceListType : ILocalPriceListType
    {
    }

    partial class JournalEntryType : ILocalJournalEntryType
    {
    }

    partial class ProductPrice : ILocalProductPrice
    {
        public int Id
        {
            get { return -1; }
        }
    }

    partial class ProductType : ILocalProductType
    {
    }

    partial class JournalEntry : ILocalJournalEntry
    {
    }

    partial class PlantStock : ILocalPlantStock
    {
    }

    partial class SeedTray : ILocalSeedTray
    {
    }

    partial class SeedBatch : ILocalSeedBatch
    {
    }

    partial class Species : ILocalSpecies
    {
    }

    partial class Genus : ILocalGenus
    {
    }
}

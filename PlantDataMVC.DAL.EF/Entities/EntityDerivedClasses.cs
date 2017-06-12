using PlantDataMVC.DAL.Interfaces;

namespace PlantDataMVC.DAL.EF.Entities
{
    partial class Site : ISite
    {
    }

    partial class PriceListType : IPriceListType
    {
    }

    partial class JournalEntryType : IJournalEntryType
    {
    }

    partial class ProductPrice : IProductPrice
    {
        public int Id
        {
            get { return -1; }
        }
    }

    partial class ProductType : IProductType
    {
    }

    partial class JournalEntry : IJournalEntry
    {
    }

    partial class PlantStock : IPlantStock
    {
    }

    partial class SeedTray : ISeedTray
    {
    }

    partial class SeedBatch : ISeedBatch
    {
    }

    partial class Species : ISpecies
    {
    }

    partial class Genus : IGenus
    {
    }
}

using Framework.DAL.Entity;

namespace PlantDataMVC.Entities.Models
{
    partial class Site : IEntity
    {
    }

    partial class PriceListType : IEntity
    {
    }

    partial class JournalEntryType : IEntity
    {
    }

    partial class ProductPrice : IEntity
    {
        // HACK: Putting Id in just to meet interface requirements
        public int Id
        {
            get { return -1; }
        }
    }

    partial class ProductType : IEntity
    {
    }

    partial class JournalEntry : IEntity
    {
    }

    partial class PlantStock : IEntity
    {
    }

    partial class SeedTray : IEntity
    {
    }

    partial class SeedBatch : IEntity
    {
    }

    partial class Species : IEntity
    {
    }

    partial class Genus : IEntity
    {
    }
}

using Framework.DAL.EF;
using Framework.DAL.Entity;

namespace PlantDataMVC.Entities.Models
{
    partial class Site : Entity
    {
    }

    partial class PriceListType : Entity
    {
    }

    partial class JournalEntryType : Entity
    {
    }

    partial class ProductPrice : Entity
    {
        // HACK: Putting Id in just to meet interface requirements
        public int Id
        {
            get { return -1; }
        }
    }

    partial class ProductType : Entity
    {
    }

    partial class JournalEntry : Entity
    {
    }

    partial class PlantStock : Entity
    {
    }

    partial class SeedTray : Entity
    {
    }

    partial class SeedBatch : Entity
    {
    }

    partial class Species : Entity
    {
    }

    partial class Genus : Entity
    {
    }
}

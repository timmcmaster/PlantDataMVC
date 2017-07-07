using Framework.DAL.EF;
using Framework.DAL.Entity;

namespace PlantDataMVC.Entities.Models
{
    partial class Site : EntityBase
    {
    }

    partial class PriceListType : EntityBase
    {
    }

    partial class JournalEntryType : EntityBase
    {
    }

    partial class ProductPrice : EntityBase
    {
        // HACK: Putting Id in just to meet interface requirements
        public override int Id
        {
            get { return -1; }
            set { }
        }
    }

    partial class ProductType : EntityBase
    {
    }

    partial class JournalEntry : EntityBase
    {
    }

    partial class PlantStock : EntityBase
    {
    }

    partial class SeedTray : EntityBase
    {
    }

    partial class SeedBatch : EntityBase
    {
    }

    partial class Species : EntityBase
    {
    }

    partial class Genus : EntityBase
    {
    }
}

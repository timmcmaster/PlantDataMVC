using Framework.DAL.EF;
using Framework.DAL.Entity;

namespace PlantDataMVC.Entities.Models
{
    partial class Site : EntityBase, IEntity
    {
    }

    partial class PriceListType : EntityBase, IEntity
    {
    }

    partial class JournalEntryType : EntityBase, IEntity
    {
    }

    partial class ProductPrice : EntityBase, IEntity
    {
        // HACK: Putting Id in just to meet interface requirements
        public int Id
        {
            get { return -1; }
        }
    }

    partial class ProductType : EntityBase, IEntity
    {
    }

    partial class JournalEntry : EntityBase, IEntity
    {
    }

    partial class PlantStock : EntityBase, IEntity
    {
    }

    partial class SeedTray : EntityBase, IEntity
    {
    }

    partial class SeedBatch : EntityBase, IEntity
    {
    }

    partial class Species : EntityBase, IEntity
    {
    }

    partial class Genus : EntityBase, IEntity
    {
    }
}

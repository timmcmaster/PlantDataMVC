using Framework.DAL.EF;
using Interfaces.DAL.Entity;
using System;

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
        public string GenericName
        {
            get { return Genus.LatinName; }
        }

        public string Binomial
        {
            get
            {
                if (string.IsNullOrEmpty(GenericName.Trim()) && string.IsNullOrEmpty(SpecificName.Trim()))
                    return "";
                else if (string.IsNullOrEmpty(GenericName.Trim()))
                    return SpecificName;
                else if (string.IsNullOrEmpty(SpecificName.Trim()))
                    return GenericName;
                else
                    return String.Format("{0} {1}", GenericName.Trim(), SpecificName.Trim());
            }
        }
    }

    partial class Genus : EntityBase
    {
    }
}

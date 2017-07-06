using Framework.DAL.EF;
using PlantDataMVC.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PlantDataMVC.Entities.Context
{
    public class GenusDbSet : MyFakeDbSet<Genus>
    {
        // TODO: Given that all entities have ID as key, 
        // we may be able to generically implement find for fakes based on given base type
        // Override Find(params object[] keyValues)
        public override Genus Find(params object[] keyValues)
        {
            var id = (int)keyValues.Single();
            return this.SingleOrDefault(g => g.Id == id);
        }

        // Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        public override Task<Genus> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return new Task<Genus>(() => Find(keyValues));
        }
    }

    public class JournalEntryDbSet : MyFakeDbSet<JournalEntry>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class JournalEntryTypeDbSet : MyFakeDbSet<JournalEntryType>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class PlantStockDbSet : MyFakeDbSet<PlantStock>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class PriceListTypeDbSet : MyFakeDbSet<PriceListType>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class ProductPriceDbSet : MyFakeDbSet<ProductPrice>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class ProductTypeDbSet : MyFakeDbSet<ProductType>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class SeedBatchDbSet : MyFakeDbSet<SeedBatch>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class SeedTrayDbSet : MyFakeDbSet<SeedTray>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class SiteDbSet : MyFakeDbSet<Site>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class SpeciesDbSet : MyFakeDbSet<Species>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }
}

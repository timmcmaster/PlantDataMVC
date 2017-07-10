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
    // TODO: Given that all entities have ID as key, we may be able to generically implement find for fakes based on given base type

    public class GenusDbSet : FakeDbSet<Genus>
    {
        public override Genus Find(params object[] keyValues)
        {
            var id = (int)keyValues.Single();
            return this.SingleOrDefault(g => g.Id == id);
        }

        public override Task<Genus> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return new Task<Genus>(() => Find(keyValues));
        }
    }

    public class JournalEntryDbSet : FakeDbSet<JournalEntry>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class JournalEntryTypeDbSet : FakeDbSet<JournalEntryType>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class PlantStockDbSet : FakeDbSet<PlantStock>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class PriceListTypeDbSet : FakeDbSet<PriceListType>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class ProductPriceDbSet : FakeDbSet<ProductPrice>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class ProductTypeDbSet : FakeDbSet<ProductType>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class SeedBatchDbSet : FakeDbSet<SeedBatch>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class SeedTrayDbSet : FakeDbSet<SeedTray>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class SiteDbSet : FakeDbSet<Site>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class SpeciesDbSet : FakeDbSet<Species>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }
}

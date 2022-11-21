using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Framework.Domain.EF;
using PlantDataMVC.Entities.EntityModels;

namespace PlantDataMVC.Entities.Context
{
    // TODO: Given that all entities have ID as key, we may be able to generically implement find for fakes based on given base type

    public class GenusDbSet : FakeDbSet<GenusEntityModel>
    {
        public override GenusEntityModel Find(params object[] keyValues)
        {
            var id = (int) keyValues.Single();
            return this.SingleOrDefault(g => g.Id == id);
        }

        public override ValueTask<GenusEntityModel> FindAsync(object[] keyValues, CancellationToken cancellationToken)
        {
            return new ValueTask<GenusEntityModel>(new Task<GenusEntityModel>(() => Find(keyValues)));
        }

        public override ValueTask<GenusEntityModel> FindAsync(params object[] keyValues)
        {
            return new ValueTask<GenusEntityModel>(new Task<GenusEntityModel>(() => Find(keyValues)));
        }
    }

    public class JournalEntryDbSet : FakeDbSet<JournalEntryEntityModel>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class JournalEntryTypeDbSet : FakeDbSet<JournalEntryTypeEntityModel>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class PlantStockDbSet : FakeDbSet<PlantStockEntityModel>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class PriceListTypeDbSet : FakeDbSet<PriceListTypeEntityModel>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class ProductPriceDbSet : FakeDbSet<ProductPriceEntityModel>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class ProductTypeDbSet : FakeDbSet<ProductTypeEntityModel>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class SaleEventDbSet : FakeDbSet<SaleEventEntityModel>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class SeedBatchDbSet : FakeDbSet<SeedBatchEntityModel>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class SeedTrayDbSet : FakeDbSet<SeedTrayEntityModel>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class SiteDbSet : FakeDbSet<SiteEntityModel>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }

    public class SpeciesDbSet : FakeDbSet<SpeciesEntityModel>
    {
        // TODO: Override Find(params object[] keyValues)
        // TODO: Override FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMvc3.DAL.LocalInterfaces
{
    /// <summary>
    /// This interface is the basic interface for ... 
    /// </summary>
    public interface ILocalEntity
    {
        int Id { get; }
    }

    public interface ILocalGenus: ILocalEntity
    {
        string LatinName { get; }
    }

    public interface ILocalSpecies : ILocalEntity
    {
        string LatinName { get; }
    }

    public interface ILocalJournalEntry : ILocalEntity
    {
    }

    public interface ILocalJournalEntryType : ILocalEntity
    {
    }

    public interface ILocalPlantStock : ILocalEntity
    {
    }

    public interface ILocalPriceListType : ILocalEntity
    {
    }

    public interface ILocalProductPrice : ILocalEntity
    {
    }

    public interface ILocalProductType : ILocalEntity
    {
    }

    public interface ILocalSeedBatch : ILocalEntity
    {
    }

    public interface ILocalSeedTray : ILocalEntity
    {
    }

    public interface ILocalSite : ILocalEntity
    {
    }

}

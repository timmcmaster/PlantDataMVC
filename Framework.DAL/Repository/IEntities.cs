using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMVC.DAL.Interfaces
{
    public interface IGenus: IEntity
    {
        string LatinName { get; }
    }

    public interface ISpecies : IEntity
    {
        string LatinName { get; }
    }

    public interface IJournalEntry : IEntity
    {
    }

    public interface IJournalEntryType : IEntity
    {
    }

    public interface IPlantStock : IEntity
    {
    }

    public interface IPriceListType : IEntity
    {
    }

    public interface IProductPrice : IEntity
    {
    }

    public interface IProductType : IEntity
    {
    }

    public interface ISeedBatch : IEntity
    {
    }

    public interface ISeedTray : IEntity
    {
    }

    public interface ISite : IEntity
    {
    }

}

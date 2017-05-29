﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMVC.DAL.Interfaces
{
    /// <summary>
    /// This interface is the basic interface for entity objects passed outside the DAL.
    /// Interactions between the Data Access Layer and the Business Layer 
    /// are all done with IEntity-derived objects. 
    /// Each object type should have an IEntity derived class to contain type-specific properties
    /// </summary>
    public interface IEntity
    {
        int Id { get; }
    }

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
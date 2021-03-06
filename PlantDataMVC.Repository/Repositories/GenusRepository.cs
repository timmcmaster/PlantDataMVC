﻿using Interfaces.DAL.Repository;
using PlantDataMVC.Entities.Models;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

/// <summary>
/// This file provides classes & interfaces to allow extension methods 
/// for <code>IRepository<Genus></code> to be mocked via a mocking framework.
/// <see href="http://blogs.clariusconsulting.net/kzu/making-extension-methods-amenable-to-mocking/"/>
/// </summary>

// Allow test assembly to be friend assembly for unit testing
[assembly: InternalsVisibleTo("PlantDataMVC.Tests.Core")]

namespace PlantDataMVC.Repository.Repositories
{
    public interface IGenusExtensions
    {
        Genus GetItemByLatinName(string latinName);
    }

    /// <summary>
    /// Grouping of extension methods specific to repository of Genus
    /// </summary>
    /// <seealso cref="PlantDataMVC.Repository.Repositories.IGenusExtensions" />
    internal class GenusExtensions : IGenusExtensions
    {
        private IRepository<Genus> _repository;

        public GenusExtensions(IRepository<Genus> genusRepository)
        {
            _repository = genusRepository;
        }

        public Genus GetItemByLatinName(string latinName)
        {
            return _repository.Queryable().FirstOrDefault(p => p.LatinName == latinName);
        }
    }

    public static class GenusRepository
    {
        public static IGenusExtensions GenusExtensions(this IRepository<Genus> target)
        {
            return GenusExtensionsFactory(target);
        }

        static GenusRepository()
        {
            GenusExtensionsFactory = gr => new GenusExtensions(gr);
        }

        // use a friend class when testing to set this
        internal static Func<IRepository<Genus>, IGenusExtensions> GenusExtensionsFactory { get; set; }
    }
}

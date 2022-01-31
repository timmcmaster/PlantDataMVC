using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Interfaces.Domain.Repository;
using PlantDataMVC.Entities.Models;

// This file provides classes & interfaces to allow extension methods 
// for <code>IRepository<Genus></code> to be mocked via a mocking framework.
// <see href="http://blogs.clariusconsulting.net/kzu/making-extension-methods-amenable-to-mocking/"/>

// Allow test assembly to be friend assembly for unit testing
[assembly: InternalsVisibleTo("PlantDataMVC.Tests.Core")]

namespace PlantDataMVC.Repository.Repositories
{
    public interface IGenusExtensions
    {
        Genus GetItemByLatinName(string latinName);
        Genus GetItemWithAllSpecies(int id);
    }

    /// <summary>
    ///     Grouping of extension methods specific to repository of Genus
    /// </summary>
    /// <seealso cref="PlantDataMVC.Repository.Repositories.IGenusExtensions" />
    internal class GenusExtensions : IGenusExtensions
    {
        private readonly IRepository<Genus> _repository;

        public GenusExtensions(IRepository<Genus> genusRepository)
        {
            _repository = genusRepository;
        }

        #region IGenusExtensions Members
        public Genus GetItemByLatinName(string latinName)
        {
            return _repository.Queryable().FirstOrDefault(g => g.LatinName == latinName);
        }

        public Genus GetItemWithAllSpecies(int id)
        {
            return _repository.Query(g => g.Id == id).Include(g => g.Species).Select().SingleOrDefault();
        }
        #endregion
    }

    public static class GenusRepository1
    {
        static GenusRepository1()
        {
            GenusExtensionsFactory = gr => new GenusExtensions(gr);
        }

        // use a friend class when testing to set this
        internal static Func<IRepository<Genus>, IGenusExtensions> GenusExtensionsFactory { get; set; }

        public static IGenusExtensions GenusExtensions(this IRepository<Genus> target)
        {
            return GenusExtensionsFactory(target);
        }
    }
}
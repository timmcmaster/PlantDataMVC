using Interfaces.Domain.Repository;
using PlantDataMVC.Entities.EntityModels;
using System;
using System.Linq;

// This file provides classes & interfaces to allow extension methods 
// for <code>IRepository<Genus></code> to be mocked via a mocking framework.
// <see href="http://blogs.clariusconsulting.net/kzu/making-extension-methods-amenable-to-mocking/"/>

namespace PlantDataMVC.Repository.Repositories
{
    public interface IGenusExtensions
    {
        GenusEntityModel GetItemByLatinName(string latinName);
        GenusEntityModel GetItemWithAllSpecies(int id);
    }

    /// <summary>
    ///     Grouping of extension methods specific to repository of Genus
    /// </summary>
    /// <seealso cref="PlantDataMVC.Repository.Repositories.IGenusExtensions" />
    internal class GenusExtensions : IGenusExtensions
    {
        private readonly IRepository<GenusEntityModel> _repository;

        public GenusExtensions(IRepository<GenusEntityModel> genusRepository)
        {
            _repository = genusRepository;
        }

        #region IGenusExtensions Members
        public GenusEntityModel GetItemByLatinName(string latinName)
        {
            return _repository.Queryable().FirstOrDefault(g => g.LatinName == latinName);
        }

        public GenusEntityModel GetItemWithAllSpecies(int id)
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

        // use a friend class/assembly when testing to set this
        internal static Func<IRepository<GenusEntityModel>, IGenusExtensions> GenusExtensionsFactory { get; set; }

        public static IGenusExtensions GenusExtensions(this IRepository<GenusEntityModel> target)
        {
            return GenusExtensionsFactory(target);
        }
    }
}
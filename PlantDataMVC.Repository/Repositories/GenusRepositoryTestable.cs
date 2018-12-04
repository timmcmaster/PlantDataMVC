using Interfaces.DAL.Repository;
using PlantDataMVC.Entities.Models;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PlantDataMVC.Tests.Core")]

namespace PlantDataMVC.Repository.Repositories
{
    public interface IGenusQueries
    {
        Genus GetItemByLatinName(string latinName);
    }


    internal class GenusQueries : IGenusQueries
    {
        private IRepository<Genus> _repository;

        public GenusQueries(IRepository<Genus> genusRepository)
        {
            _repository = genusRepository;
        }

        public Genus GetItemByLatinName(string latinName)
        {
            return _repository.Queryable().FirstOrDefault(p => p.LatinName == latinName);
        }
    }

    public static class GenusRepository2
    {
        public static IGenusQueries GenusQueries(this IRepository<Genus> target)
        {
            return GenusQueriesFactory(target);
        }

        static GenusRepository2()
        {
            GenusQueriesFactory = gr => new GenusQueries(gr);
        }

        // use a friend class when testing to set this
        internal static Func<IRepository<Genus>, IGenusQueries> GenusQueriesFactory { get; set; }
    }
}

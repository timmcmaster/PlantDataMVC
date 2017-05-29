using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace PlantDataMVC.DAL.MappingRepositories
{
    public class SortOrder<TEntity,TKey>
    {
        private Expression<Func<TEntity, TKey>> _sortOrder;

        public SortOrder(Expression<Func<TEntity, TKey>> orderExpression)
        {
            _sortOrder = orderExpression;
        }

        public Expression<Func<TEntity, TKey>> Get()
        {
            return _sortOrder;
        }
    }
}

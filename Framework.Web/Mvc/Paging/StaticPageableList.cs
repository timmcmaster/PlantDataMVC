using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Web.Mvc.Paging
{
    public class StaticPageableList<T> : BasePageableList<T>
    {
        public StaticPageableList(IEnumerable<T> pageOfData, int pageNumber, int pageSize, int totalCount): base(pageNumber,pageSize,totalCount)
        {
            AddRange(pageOfData);
        }
    }
}

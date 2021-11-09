using System;
using System.Collections.Generic;
namespace Paged
{

    [Serializable]
    public class StaticPagedList<T> : BasePagedList<T>
    {
        public StaticPagedList(IEnumerable<T> subset, IPagedList metaData) : this(subset, metaData.PageNumber, metaData.PageSize, metaData.TotalCount)
        {
        }

        public StaticPagedList(IEnumerable<T> subset, int pageNumber, int pageSize, int totalCount) : base(pageNumber, pageSize, totalCount)
        {
            Subset.AddRange(subset);
        }
    }
}


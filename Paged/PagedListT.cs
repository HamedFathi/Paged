using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Paged
{
    [Serializable]
    public class PagedList<T> : BasePagedList<T>
    {
        public PagedList(IQueryable<T> superset, int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(pageNumber), pageNumber, "PageNumber cannot be below 1.");
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "PageSize cannot be less than 1.");
            TotalCount = (superset != null) ? Queryable.Count(superset) : 0;
            PageSize = pageSize;
            PageNumber = pageNumber;
            PageCount = (TotalCount > 0) ? ((int)Math.Ceiling(TotalCount / (double)PageSize)) : 0;
            HasPreviousPage = PageNumber > 1;
            HasNextPage = PageNumber < PageCount;
            IsFirstPage = PageNumber == 1;
            IsLastPage = PageNumber >= PageCount;
            FirstItemOnPage = (PageNumber - 1) * PageSize + 1;
            int num = FirstItemOnPage + PageSize - 1;
            LastItemOnPage = (num > TotalCount) ? TotalCount : num;
            if (superset != null && TotalCount > 0)
                Subset.AddRange((pageNumber == 1) ? Enumerable.ToList(Queryable.Skip(superset, 0).Take(pageSize)) : Enumerable.ToList(Queryable.Skip(superset, (pageNumber - 1) * pageSize).Take(pageSize)));
        }

        public PagedList(IEnumerable<T> superset, int pageNumber, int pageSize)
                    : this(Queryable.AsQueryable(superset), pageNumber, pageSize)
        {
        }

        internal PagedList()
        {
        }

        internal static async Task<IPagedList<T>> CreateAsync(IQueryable<T> superset, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(pageNumber), pageNumber, "PageNumber cannot be below 1.");
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "PageSize cannot be less than 1.");
            PagedList<T> paged = new PagedList<T>();
            paged.TotalCount = (superset != null) ? (await superset.CountAsync(cancellationToken)) : 0;
            paged.PageSize = pageSize;
            paged.PageNumber = pageNumber;
            paged.PageCount = (paged.TotalCount > 0) ? ((int)Math.Ceiling(paged.TotalCount / (double)paged.PageSize)) : 0;
            paged.HasPreviousPage = paged.PageNumber > 1;
            paged.HasNextPage = paged.PageNumber < paged.PageCount;
            paged.IsFirstPage = paged.PageNumber == 1;
            paged.IsLastPage = paged.PageNumber >= paged.PageCount;
            paged.FirstItemOnPage = (paged.PageNumber - 1) * paged.PageSize + 1;
            int numberOfLastItemOnPage = paged.FirstItemOnPage + paged.PageSize - 1;
            paged.LastItemOnPage = (numberOfLastItemOnPage > paged.TotalCount) ? paged.TotalCount : numberOfLastItemOnPage;
            if (superset != null && paged.TotalCount > 0)
                paged.Subset.AddRange((pageNumber == 1) ? (await Queryable.Take(Queryable.Skip(superset, 0), pageSize).ToListAsync(cancellationToken)) : (await Queryable.Take(Queryable.Skip(superset, (pageNumber - 1) * pageSize), pageSize).ToListAsync(cancellationToken)));
            return paged;
        }


    }
}

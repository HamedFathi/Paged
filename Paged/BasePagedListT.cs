using System;
using System.Collections;
using System.Collections.Generic;

namespace Paged
{
    [Serializable]
    public abstract class BasePagedList<T> : PagedListMetaData, IPagedList<T>, IPagedList, IEnumerable<T>, IEnumerable
    {
        protected readonly List<T> Subset;

        public int Count =>
                    Subset.Count;

        public T this[int index] =>
                    Subset[index];

        protected internal BasePagedList()
        {
            Subset = new List<T>();
        }

        protected internal BasePagedList(int pageNumber, int pageSize, int totalItemCount)
        {
            Subset = new List<T>();
            if (pageNumber < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageNumber), pageNumber, "PageNumber cannot be below 1.");
            }
            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "PageSize cannot be less than 1.");
            }
            TotalCount = totalItemCount;
            PageSize = pageSize;
            PageNumber = pageNumber;
            PageCount = (TotalCount > 0) ? ((int)Math.Ceiling((double)(TotalCount / ((double)PageSize)))) : 0;
            HasPreviousPage = PageNumber > 1;
            HasNextPage = PageNumber < PageCount;
            IsFirstPage = PageNumber == 1;
            IsLastPage = PageNumber >= PageCount;
            FirstItemOnPage = ((PageNumber - 1) * PageSize) + 1;
            int num = FirstItemOnPage + PageSize - 1;
            LastItemOnPage = (num > TotalCount) ? TotalCount : num;
        }

        public IEnumerator<T> GetEnumerator() =>
                    Subset.GetEnumerator();

        public IPagedList GetMetaData() =>
                    new PagedListMetaData(this);

        IEnumerator IEnumerable.GetEnumerator() =>
                    GetEnumerator();
    }
}

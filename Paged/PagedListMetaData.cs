using System;

namespace Paged
{
    [Serializable]
    public class PagedListMetaData : IPagedList
    {
        public int FirstItemOnPage { get; protected set; }

        public bool HasNextPage { get; protected set; }

        public bool HasPreviousPage { get; protected set; }

        public bool IsFirstPage { get; protected set; }

        public bool IsLastPage { get; protected set; }

        public int LastItemOnPage { get; protected set; }

        public int PageCount { get; protected set; }

        public int PageNumber { get; protected set; }

        public int PageSize { get; protected set; }

        public int TotalCount { get; protected set; }

        protected PagedListMetaData()
        {
        }

        public PagedListMetaData(IPagedList pagedList)
        {
            PageCount = pagedList.PageCount;
            TotalCount = pagedList.TotalCount;
            PageNumber = pagedList.PageNumber;
            PageSize = pagedList.PageSize;
            HasPreviousPage = pagedList.HasPreviousPage;
            HasNextPage = pagedList.HasNextPage;
            IsFirstPage = pagedList.IsFirstPage;
            IsLastPage = pagedList.IsLastPage;
            FirstItemOnPage = pagedList.FirstItemOnPage;
            LastItemOnPage = pagedList.LastItemOnPage;
        }
    }
}

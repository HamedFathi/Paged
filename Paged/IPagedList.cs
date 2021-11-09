namespace Paged
{
    public interface IPagedList
    {
        int FirstItemOnPage { get; }

        bool HasNextPage { get; }

        bool HasPreviousPage { get; }

        bool IsFirstPage { get; }

        bool IsLastPage { get; }

        int LastItemOnPage { get; }

        int PageCount { get; }

        int PageNumber { get; }

        int PageSize { get; }

        int TotalCount { get; }
    }
}

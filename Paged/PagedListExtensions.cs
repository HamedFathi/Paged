using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paged
{
    public static class PagedListExtensions
    {
        public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> items, int pageNumber, int pageSize)
        {
            return new PagedList<T>(items, pageNumber, pageSize);
        }

        public static IPagedList<T> ToPagedList<T>(this IQueryable<T> items, int pageNumber, int pageSize)
        {
            return new PagedList<T>(items, pageNumber, pageSize);
        }

        public static IPagedList<T> ToPagedList<T>(this T[] items, int pageNumber, int pageSize)
        {
            return new PagedList<T>(items, pageNumber, pageSize);
        }

        public static Task<IPagedList<T>> ToPagedListAsync<T>(this IQueryable<T> items, int pageNumber, int pageSize)
        {
            return PagedList<T>.CreateAsync(items, pageNumber, pageSize);
        }

        public static Task<IPagedList<T>> ToPagedListAsync<T>(this IEnumerable<T> items, int pageNumber, int pageSize)
        {
            return PagedList<T>.CreateAsync(items.AsQueryable(), pageNumber, pageSize);
        }

        public static Task<IPagedList<T>> ToPagedListAsync<T>(this T[] items, int pageNumber, int pageSize)
        {
            return PagedList<T>.CreateAsync(items.AsQueryable(), pageNumber, pageSize);
        }
    }
}

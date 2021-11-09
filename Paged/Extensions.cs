using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Paged
{
    internal static class Extensions
    {
        internal static Task<int> CountAsync<TSource>(this IQueryable<TSource> source, CancellationToken cancellationToken = default)
        {
            return Task.Run(() => source.Count(), cancellationToken);
        }
        internal static Task<List<TSource>> ToListAsync<TSource>(this IQueryable<TSource> query, CancellationToken cancellationToken = default)
        {
            return Task.Run(() => query.ToList(), cancellationToken);
        }
    }
}

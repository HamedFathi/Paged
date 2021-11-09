using System.Collections;
using System.Collections.Generic;

namespace Paged
{
    public interface IPagedList<out T> : IPagedList, IEnumerable<T>, IEnumerable
    {
        int Count { get; }

        T this[int index] { get; }

        IPagedList GetMetaData();
    }
}

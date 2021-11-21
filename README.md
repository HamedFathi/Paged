![left-right](https://user-images.githubusercontent.com/8418700/140856321-6704e41e-33ef-499e-842f-513ffcc6882d.png)

### [Nuget](https://www.nuget.org/packages/Paged/)

[![Open Source Love](https://badges.frapsoft.com/os/mit/mit.svg?v=102)](https://opensource.org/licenses/MIT)
![Nuget](https://img.shields.io/nuget/v/Paged)
![Nuget](https://img.shields.io/nuget/dt/Paged)

```
Install-Package Paged

dotnet add package Paged
```

### Methods

There are six extension methods (sync & async) as following:

```cs
using Paged;

// Sync
IPagedList<T> ToPagedList<T>(this IEnumerable<T> items, int pageNumber, int pageSize)
IPagedList<T> ToPagedList<T>(this IQueryable<T> items, int pageNumber, int pageSize)
IPagedList<T> ToPagedList<T>(this T[] items, int pageNumber, int pageSize)

// Async
Task<IPagedList<T>> ToPagedListAsync<T>(this IQueryable<T> items, int pageNumber, int pageSize)
Task<IPagedList<T>> ToPagedListAsync<T>(this IEnumerable<T> items, int pageNumber, int pageSize)
Task<IPagedList<T>> ToPagedListAsync<T>(this T[] items, int pageNumber, int pageSize)
```

### PagedList

The details of each page include the following:

```cs
// IPagedList<T> for sync version
// Task<IPagedList<T>> for async version

int  Count
int  FirstItemOnPage
bool HasNextPage
bool HasPreviousPage
bool IsFirstPage
bool IsLastPage
int  LastItemOnPage
int  PageCount
int  PageNumber
int  PageSize
int  TotalCount
```

<hr/>
<div>Icons made by <a href="https://www.flaticon.com/authors/lafs" title="LAFS">LAFS</a> from <a href="https://www.flaticon.com/" title="Flaticon">www.flaticon.com</a></div>

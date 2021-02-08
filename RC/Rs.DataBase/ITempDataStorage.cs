using System;
using System.Linq;

namespace Rs.DataBase
{
    public interface ITempDataStorage<T> : IQueryable<T>, IDisposable, IAsyncDisposable where T : class
    {
    }
}
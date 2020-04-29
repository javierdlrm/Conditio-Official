using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conditio.Core
{
    public interface IRepository<T>
    {
        Task AddAsync(T item);
        Task UpdateAsync(string id, T item);
        Task<T> GetAsync(string id);
        Task DeleteAsync(string id);
    }
}

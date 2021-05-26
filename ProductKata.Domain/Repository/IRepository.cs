using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductKata.Domain.Repository
{
    public interface IRepository<T>
    {
        Task<int> Add(T item);
        Task<T> Update(T item);
        Task<T> Get(int id);
        Task<IEnumerable<T>> Get();
    }
}

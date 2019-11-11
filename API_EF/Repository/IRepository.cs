using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocAPI.Repository
{
    public interface IRepository<T>
    {
        T Get(long id);
        IEnumerable<T> All();
        void Add(T entity);
        void Update(long id, T entity);
        void Delete(long id);

    }
}

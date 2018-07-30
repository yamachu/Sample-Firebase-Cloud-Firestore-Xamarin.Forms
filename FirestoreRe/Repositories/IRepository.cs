using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirestoreRe.Repositories
{
    public interface IRepository<T>
    {
        T GetOne(string id);
        Task<T> GetOneAsync(string id);

        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
    }
}

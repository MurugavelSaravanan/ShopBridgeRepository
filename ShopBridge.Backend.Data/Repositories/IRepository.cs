using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Backend.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task Insert(T entityToInsert);
        Task Update(T entityToUpdate);
        Task Delete(object id);

    }
}

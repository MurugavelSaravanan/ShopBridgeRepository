using Microsoft.EntityFrameworkCore;
using ShopBridge.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Backend.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ShopBridgeDbContext context;
        protected async Task Save() => await context.SaveChangesAsync();
        public Repository(ShopBridgeDbContext context)
        {
            this.context = context;
        }

        //To get all items from the table
        public IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        //To insert an item into the table
        public virtual async Task Insert(T entityToInsert)
        {
            context.Set<T>().Add(entityToInsert);
            await Save();
        }

        //To update an item in the table
        public virtual async Task Update(T entityToUpdate)
        {
            context.Set<T>().Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
            await Save();
        }

        //To delete an item from table
        public virtual async Task Delete(object id)
        {
            T entityToDelete = context.Set<T>().Find(id);
            await Delete(entityToDelete);
        }
    }
}

using ShopBridge.Data;
using ShopBridge.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridge.Backend.Data.Repositories
{
    public interface IItemDetailsRepository : IRepository<ItemDetails>
    {

    }
    public class ItemDetailsRepository : Repository<ItemDetails>, IItemDetailsRepository
    {
        public ItemDetailsRepository(ShopBridgeDbContext context) : base(context)
        {

        }
    }
}

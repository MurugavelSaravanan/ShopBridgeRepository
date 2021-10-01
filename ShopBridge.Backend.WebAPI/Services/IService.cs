using ShopBridge.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Backend.WebAPI.Services
{
    public interface IService
    {
        public List<ItemDetails> GetAllItemDetails();
        public Task<string> AddItem(ItemDetails itemDetails);
        public Task<string> UpdateItem(ItemDetails itemDetails);
        public Task<string> DeleteItem(int id);
    }
}

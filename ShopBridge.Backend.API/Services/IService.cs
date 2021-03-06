using ShopBridge.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Backend.API.Services
{
    public interface IService
    {
        public List<ItemDetails> GetAllItemDetails();
        public Task<string> AddItem(ItemDetails itemDetails);
        public Task<string> UpdateItem(ItemDetails itemDetails);
        public Task<string> DeleteItem(int id);
    }
}

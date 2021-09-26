using ShopBridge.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridge.Backend.API.Services
{
    public interface IService
    {
        public List<ItemDetails> GetAllItemDetails();
        public string AddItem(ItemDetails itemDetails);
        public string UpdateItem(ItemDetails itemDetails);
        public string DeleteItem(int id);
    }
}

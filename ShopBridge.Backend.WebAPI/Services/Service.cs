using ShopBridge.Backend.Data.Repositories;
using ShopBridge.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Backend.WebAPI.Services
{
    public class Service : IService
    {
        private readonly IItemDetailsRepository itemDetailsRepository;
        string message;
        public Service(IItemDetailsRepository itemRepository)
        {
            this.itemDetailsRepository = itemRepository;
        }

        //Method to get all the items
        public List<ItemDetails> GetAllItemDetails()
        {
            return itemDetailsRepository.GetAll().ToList();
        }

        //Method to add an item
        public async Task<string> AddItem(ItemDetails itemDetails)
        {
            try
            {
                await itemDetailsRepository.Insert(itemDetails);
                message = "Item Added Successfully";
            }
            catch (Exception exception)
            {
                return exception.InnerException.Message;
            }
            return message;
        }

        //Method to update an item
        public async Task<string> UpdateItem(ItemDetails itemDetails)
        {
            try
            {
                await itemDetailsRepository.Update(itemDetails);
                message = "Item Updated Successfully";
            }
            catch (Exception exception)
            {
                return exception.InnerException.Message;
            }
            return message;
        }

        //Method to delete an item based on id
        public async Task<string> DeleteItem(int id)
        {
            try
            {
                await itemDetailsRepository.Delete(id);
                message = "Item Deleted Successfully";
            }
            catch (Exception exception)
            {
                return exception.InnerException.Message;
            }
            return message;
        }
    }
}

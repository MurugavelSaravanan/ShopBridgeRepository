using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopBridge.Backend.WebAPI.Services;
using ShopBridge.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Backend.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemDetailsController : ControllerBase
    {
        private IService service;
        public ItemDetailsController(IService service)
        {
            this.service = service;
        }
        string responseMessage;

        //To get all the items
        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            List<ItemDetails> itemDetails;
            try
            {
                itemDetails = service.GetAllItemDetails();
            }
            catch (Exception exception)
            {
                return new OkObjectResult(exception.InnerException.Message);
            }
            return new OkObjectResult(itemDetails);
        }

        //To Add an item
        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] ItemDetails inputData)
        {
            try
            {
                if (inputData == null)
                {
                    return new BadRequestResult();
                }
            }
            catch
            {
                return new BadRequestResult();
            }
            try
            {
                responseMessage =await service.AddItem(inputData);
            }
            catch (Exception exception)
            {
                return new OkObjectResult(exception.InnerException.Message);
            }
            return new OkObjectResult(responseMessage);
        }

        //To update an item
        [HttpPut]
        public async Task<IActionResult> UpdateItem([FromBody] ItemDetails inputData)
        {
            try
            {
                if (inputData == null)
                {
                    return new BadRequestResult();
                }
            }
            catch
            {
                return new BadRequestResult();
            }
            try
            {
                responseMessage =await service.UpdateItem(inputData);
            }
            catch (Exception exception)
            {
                return new OkObjectResult(exception.InnerException.Message);
            }
            return new OkObjectResult(responseMessage);
        }

        //To delete an item
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            try
            {
                responseMessage = await service.DeleteItem(id);
            }
            catch (Exception exception)
            {
                return new OkObjectResult(exception.InnerException.Message);
            }
            return new OkObjectResult(responseMessage);
        }
    }
}

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShopBridge.Backend.API.Services;
using ShopBridge.Data.Entities;

namespace ShopBridge.Backend.API.AzureFunctions
{
    //Azure function to update an item
    public class UpdateItem
    {
        private IService service;
        public UpdateItem(IService service)
        {
            this.service = service;
        }
        [FunctionName("UpdateItem")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "updateitem")] HttpRequest req,
            ILogger log)
        {
            ItemDetails inputData;
            string responseMessage;
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            try
            {
                inputData = JsonConvert.DeserializeObject<ItemDetails>(requestBody);
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
                responseMessage=await service.UpdateItem(inputData);
            }
            catch (Exception exception)
            {
                return new OkObjectResult(exception.InnerException.Message);
            }
            return new OkObjectResult(responseMessage);
        }
    }
}

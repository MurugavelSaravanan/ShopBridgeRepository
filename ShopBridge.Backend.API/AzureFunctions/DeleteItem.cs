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

namespace ShopBridge.Backend.API.AzureFunctions
{
    //Azure function to delete an item based on the id
    public class DeleteItem
    {
        private IService service;
        public DeleteItem(IService service)
        {
            this.service = service;
        }
        [FunctionName("DeleteItem")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "deleteitem/{id}")] HttpRequest req,
            int id,
            ILogger log)
        {
            string responseMessage;
            try
            {
                responseMessage = service.DeleteItem(id);
            }
            catch (Exception exception)
            {
                return new OkObjectResult(exception.InnerException.Message);
            }
            return new OkObjectResult(responseMessage);
        }
    }
}

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
using System.Collections.Generic;

namespace ShopBridge.Backend.API.AzureFunctions
{
    //Azure function to get all the items
    public class GetAllItemDetails
    {
        private IService service;
        public GetAllItemDetails(IService service)
        {
            this.service = service;
        }
        [FunctionName("GetAllItemDetails")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "itemdetails")] HttpRequest req,
            ILogger log)
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
    }
}

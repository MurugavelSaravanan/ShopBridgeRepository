using NUnit.Framework;
using ShopBridge.Backend.API.Services;
using ShopBridge.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Backend.Test.ItemDetailsUnitTest
{
    public class ItemDetailsServiceUnitTest : BaseEntityTest
    {
        [Test]
        public void GetAllItemDetails_SuccessTest()
        {
            //Arrange
            var service = new Service(itemDetailsRepository.Object);

            //Act
            var itemDetails = service.GetAllItemDetails();

            //Assert
            Assert.IsNotNull(itemDetails);
            Assert.AreEqual(itemDetails.Count, 2);
        }
        [Test]
        public async Task AddItem_SuccessTest()
        {
            //Arrange
            var service = new Service(itemDetailsRepository.Object);

            //Act
            var itemDetails = new ItemDetails() { Id = 1, Name = "Redmi Note 7", Price = 9000, Description = "Redmi Note 7 has 4000Mah battery", ItemsInStock = 10 };
            var responseMessage =await service.AddItem(itemDetails);

            //Assert
            Assert.AreEqual(responseMessage,"Item Added Successfully");
        }
        [Test]
        public async Task UpdateItem_SuccessTest()
        {
            //Arrange
            var service = new Service(itemDetailsRepository.Object);

            //Act
            var itemDetails = new ItemDetails() { Id = 1, Name = "Redmi Note 7", Price = 9000, Description = "Redmi Note 7 has 4000Mah battery", ItemsInStock = 10 };
            var responseMessage = await service.UpdateItem(itemDetails);

            //Assert
            Assert.AreEqual(responseMessage, "Item Updated Successfully");
        }
        [Test]
        public async Task DeleteItem_SuccessTest()
        {
            //Arrange
            var service = new Service(itemDetailsRepository.Object);

            //Act
            var responseMessage =await service.DeleteItem(1);

            //Assert
            Assert.AreEqual(responseMessage, "Item Deleted Successfully");
        }
    }
}

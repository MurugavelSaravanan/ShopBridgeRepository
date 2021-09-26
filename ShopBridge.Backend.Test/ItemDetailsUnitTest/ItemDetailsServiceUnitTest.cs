using NUnit.Framework;
using ShopBridge.Backend.API.Services;
using ShopBridge.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
        public void AddItem_SuccessTest()
        {
            //Arrange
            var service = new Service(itemDetailsRepository.Object);

            //Act
            var itemDetails = new ItemDetails() { Id = 1, Name = "Redmi Note 7", Price = 9000, Description = "Redmi Note 7 has 4000Mah battery", ItemsInStock = 10 };
            var responseMessage = service.AddItem(itemDetails);

            //Assert
            Assert.AreEqual(responseMessage,"Item Added Successfully");
        }
        [Test]
        public void UpdateItem_SuccessTest()
        {
            //Arrange
            var service = new Service(itemDetailsRepository.Object);

            //Act
            var itemDetails = new ItemDetails() { Id = 1, Name = "Redmi Note 7", Price = 9000, Description = "Redmi Note 7 has 4000Mah battery", ItemsInStock = 10 };
            var responseMessage = service.UpdateItem(itemDetails);

            //Assert
            Assert.AreEqual(responseMessage, "Item Updated Successfully");
        }
        [Test]
        public void DeleteItem_SuccessTest()
        {
            //Arrange
            var service = new Service(itemDetailsRepository.Object);

            //Act
            var responseMessage = service.DeleteItem(1);

            //Assert
            Assert.AreEqual(responseMessage, "Item Deleted Successfully");
        }
    }
}

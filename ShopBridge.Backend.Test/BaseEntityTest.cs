using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using ShopBridge.Backend.Data.Repositories;
using ShopBridge.Data;
using ShopBridge.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Backend.Test
{
    public class BaseEntityTest
    {
        protected Mock<IItemDetailsRepository> itemDetailsRepository;
        protected Mock<ShopBridgeDbContext> mockDbContext;

        [SetUp]
        public void Setup()
        {
            var itemDetails = new List<ItemDetails>()
            {
                new ItemDetails(){Id=1,Name="Redmi Note 7",Price=9000,Description="Redmi Note 7 has 4000Mah battery",ItemsInStock=10},
                new ItemDetails(){Id=2,Name="Redmi Note 8",Price=11000,Description="Redmi Note 8 has 4500Mah battery",ItemsInStock=15}
            };

            itemDetailsRepository = new Mock<IItemDetailsRepository>();
            itemDetailsRepository.Setup(d => d.Insert(It.IsAny<ItemDetails>())).Returns(Task.FromResult(new List<ItemDetailsRepository>()));
            itemDetailsRepository.Setup(d => d.GetAll()).Returns(itemDetails);
            itemDetailsRepository.Setup(d => d.Update(It.IsAny<ItemDetails>()));
            itemDetailsRepository.Setup(d => d.Delete(1));

            var itemDetailsQueryable = itemDetails.AsQueryable();
            Mock<DbSet<ItemDetails>> resItemDetailsSet = new Mock<DbSet<ItemDetails>>();
            resItemDetailsSet.As<IQueryable<ItemDetails>>().Setup(m => m.Expression).Returns(itemDetailsQueryable.Expression);
            resItemDetailsSet.As<IQueryable<ItemDetails>>().Setup(m => m.ElementType).Returns(itemDetailsQueryable.ElementType);
            resItemDetailsSet.As<IQueryable<ItemDetails>>().Setup(m => m.GetEnumerator()).Returns(itemDetailsQueryable.GetEnumerator);

            mockDbContext = new Mock<ShopBridgeDbContext>();

            mockDbContext.Setup(x => x.Set<ItemDetails>()).Returns(resItemDetailsSet.Object);
        }
    }
}

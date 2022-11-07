using AlmatyApi.Context;
using AlmatyApi.Controllers;
using AlmatyApi.DataAccess;
using AlmatyApi.Models;
using AlmatyApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AlmatyApi.Tests
{
    public class ControllerIntegrationTests
    {
        private List<MovedGoodsView> GetTestSessions()
        {
            var fake = new List<MovedGoodsView>();
            fake.Add(new MovedGoodsView { NomenclatureName = "1", WarehouseFrom = "1", WarehouseTo = "2", Date = DateTime.Now, Ammount = 100 });
            fake.Add(new MovedGoodsView { NomenclatureName = "1", WarehouseFrom = "3", WarehouseTo = "2", Date = DateTime.Now, Ammount = 100 });
            return fake;
        }
        [Fact]
        public void GetMovedGoodsAsync_ReturnsCollection()
        {
            // Arrange           
            var mockRepo = new Mock<IGoodsService>();
            mockRepo.Setup(_ => _.GetAllMovedGoodsAsync(2))
                .ReturnsAsync(GetTestSessions());

            var controller = new GoodsController(mockRepo.Object);

            // Act
            var result = controller.GetMovedGoodsAsync(2);
            // Assert
            Assert.IsType<OkObjectResult>(result.Result);           
        }
        [Fact]
        public void NewGoodsMovementAsync_WorksAsIntended()
        {
           var options = new DbContextOptionsBuilder<SQLLocalDBContext>()
          .UseInMemoryDatabase(databaseName: "Test")
          .EnableSensitiveDataLogging()
          .Options;

            var testGoods = new MoovedGoods { NomenclatureId = 1, WarehouseFromId = 1, WarehouseToId = 2, Date = DateTime.Now, Ammount = 100 };

            using (var context = new SQLLocalDBContext(options))
            {
                // Arrange
                context.MoovedGoods.Add(testGoods);
                context.SaveChanges();
            }
            using (var context = new SQLLocalDBContext(options))
            {
                var data = new DBAccess(context);
                var servie = new GoodsService(data);

                // Act
                var controller = new GoodsController(servie);

                // Act
                var result = controller.NewGoodsMovementAsync(testGoods);
                // Assert
                Assert.Equal(2, context.MoovedGoods.Count());
            }
        }
    }
}

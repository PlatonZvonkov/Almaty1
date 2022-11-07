using AlmatyApi.Context;
using AlmatyApi.DataAccess;
using AlmatyApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using Moq;
using AlmatyApi.Services;
using System.Linq;

namespace AlmatyApi.Tests
{
    public class GoodsServiceTests
    {
        [Fact]
        public void DeleteGoods_WorksCorrectly()
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
                var repo = new GoodsService(data);
               
                // Act
                repo.DeleteMovedGoodsByModel(testGoods);
                // Assert
                Assert.Equal(0, context.MoovedGoods.Count());
            }
        }
    }
}

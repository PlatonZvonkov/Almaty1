using AlmatyApi.Context;
using AlmatyApi.DataAccess;
using AlmatyApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace AlmatyApi.Tests
{
    public class DataAccessIntegrationTests
    {
        [Fact]
        public async void PostMailAsync_Add_WorkingAsIntended()
        {
            var options = new DbContextOptionsBuilder<SQLLocalDBContext>()
            .UseInMemoryDatabase(databaseName: "Test")
            .EnableSensitiveDataLogging()
            .Options;

            using (var context = new SQLLocalDBContext(options))
            {
                // Arrange
                context.MoovedGoods.Add(new MoovedGoods { NomenclatureId = 1, WarehouseFromId = 1, WarehouseToId = 2, Date = DateTime.Now, Ammount = 100 });
                context.SaveChanges();
            }
            using (var context = new SQLLocalDBContext(options))
            {
                var st = new MoovedGoods { NomenclatureId = 2, WarehouseFromId = 3, WarehouseToId = 2, Date = DateTime.Now, Ammount = 100 };
                var repo = new DBAccess(context);

                // Act
                await repo.PostMovedGoods(st);
                // Assert
                Assert.Equal(2, context.MoovedGoods.Count());
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CinemaAPI.Tests
{
    public class SnackServiceTests
    {




        private void SeedSnacks(CinemaDbContext context)
        {

            var snacks = new[]
            {

                new Snack {SnackId = 1, Name = "Pop Corn", Size = "Small", Cost = 5.99 },
                new Snack {SnackId = 2, Name = "Coke", Size = "Large", Cost = 6.20 },
                new Snack {SnackId = 3, Name = "Snickers", Size = "Small", Cost = 2.50 },
                new Snack {SnackId = 4, Name = "Pizza", Size = "Regular", Cost = 8.99 },
                new Snack {SnackId = 5, Name = "Nachos + Coke", Size = "Large", Cost = 12.50 },
                new Snack {SnackId = 6, Name = "Nachos", Size = "Small", Cost = 8.99 }


            };

            context.Snack.AddRange(snacks);
            context.SaveChanges();

        }

        [Fact]
        public void ADD_ShouldReturnSnackAdded()
        {

            //Arrange
            int x = 7;
            var snack = new Snack() { SnackId = x, Name = "M&M", Size = "Small", Cost = 3.50 };
            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase(databaseName: "ADD_ShouldReturnSnackAdded")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            var context = new CinemaDbContext(options);

            SeedSnacks(context);

            var service = new SnackService(context);

            //Act
            var result = service.Add(snack);


            //Assert
            Assert.True(result);

        }


        [Fact]
        public void GET_ShouldReturnSnackById2()
        {

            //Arrange
            int x = 5;
            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase(databaseName: "GET_ShouldReturnSnackById5")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            var context = new CinemaDbContext(options);

            SeedSnacks(context);

            var service = new SnackService(context);

            //Act
            var result = service.Select(x);


            //Assert
            Assert.Equal(result.SnackId, x);

        }

        [Fact]
        public void GETALL_ShouldReturnAllSnacks()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase(databaseName: "GETALL_ShouldReturnAllSnacks")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            var context = new CinemaDbContext(options);

            SeedSnacks(context);

            var service = new SnackService(context);

            //Act
            var result = service.SelectAll().ToList();


            //Assert
            Assert.Equal(6, result.Count);




        }

        [Fact]
        public void UPDATE_ShouldReturnNewName()
        {


            //Arrange
            var x = 6;
            var Snack = new Snack { SnackId = 7, Name = "Pizza", Size = "Large", Cost = 14.50 };

            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase(databaseName: "UPDATE_ShouldReturnNewName")
                .Options;

            var context = new CinemaDbContext(options);

            SeedSnacks(context);

            var service = new SnackService(context);

            //Act
            var result = service.Update(x, Snack);


            //Assert
            Assert.Equal(result.Name, Snack.Name);

        } 

        [Fact]
        public void DELETE_ShouldReturnOneSnackLess()
        {

            //Arrange
            int x = 1;
            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase(databaseName: "DELETE_ShouldReturnOneSnackLess")
                .Options;


            var context = new CinemaDbContext(options);

            SeedSnacks(context);

            var service = new SnackService(context);


            //Act
            var result = service.Delete(x);


            //Assert
            Assert.True(result);

        }



    }
}

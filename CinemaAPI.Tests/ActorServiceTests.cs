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
    public class ActorServiceTests
    {




        private void SeedActors(CinemaDbContext context)
        {

            var actors = new[]
            {

                new Actor {ActorId = 1, FirstName = "Robert", LastName = "Redfort", Age = 64, Gender = 'M', Rating ="7.2/10"},
                new Actor {ActorId = 2, FirstName = "Tom", LastName = "Holland", Age = 23, Gender = 'M', Rating ="7.5/10"},
                new Actor {ActorId = 3, FirstName = "Zoe", LastName = "Saldaña", Age = 37, Gender = 'F', Rating ="8.1/10"},
                new Actor {ActorId = 4, FirstName = "Vin", LastName = "Diesel", Age = 42, Gender = 'M', Rating ="8.9/10"}

            };

            context.Actor.AddRange(actors);
            context.SaveChanges();

        }

        [Fact]
        public void ADD_ShouldReturnActorAdded()
        {

            //Arrange
            int x = 5;
            var actor = new Actor() { ActorId = x, FirstName = "Mark", LastName = "Walhberg", Age = 44, Gender = 'M', Rating = "8.5/10" };
            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase(databaseName: "ADD_ShouldReturnActorAdded")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            var context = new CinemaDbContext(options);

            SeedActors(context);

            var service = new ActorService(context);

            //Act
            var result = service.Add(actor);


            //Assert
            Assert.Equal(result.ActorId, actor.ActorId);

        }


        [Fact]
        public void GET_ShouldReturnActorById2()
        {

            //Arrange
            int x = 2;
            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase(databaseName: "GET_ShouldReturnActorById2")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            var context = new CinemaDbContext(options);

            SeedActors(context);

            var service = new ActorService(context);

            //Act
            var result = service.Select(x);


            //Assert
            Assert.Equal(result.ActorId, x);

        }

        [Fact]
        public void GETALL_ShouldReturnAllActors()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase(databaseName: "GETALL_ShouldReturnAllActors")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            var context = new CinemaDbContext(options);

            SeedActors(context);

            var service = new ActorService(context);

            //Act
            var result = service.SelectAll().ToList();


            //Assert
            Assert.Equal(4, result.Count);




        }

        [Fact]
        public void UPDATE_ShouldReturnNewName()
        {


            //Arrange
            var x = 2;
            var actor = new Actor { ActorId = x, FirstName = "Sarah Jessica", LastName = "Parker", Age = 54, Gender = 'F', Rating = "6.5/10" };

            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase(databaseName: "UPDATE_ShouldReturnNewName")
                .Options;

            var context = new CinemaDbContext(options);

            SeedActors(context);

            var service = new ActorService(context);

            //Act
            var result = service.Update(x, actor);


            //Assert
            Assert.Equal(result.FirstName, actor.FirstName);

        } 

        [Fact]
        public void DELETE_ShouldReturnOneActorLess()
        {

            //Arrange
            int x = 4;
            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase(databaseName: "DELETE_ShouldReturnOneActorLess")
                .Options;


            var context = new CinemaDbContext(options);

            SeedActors(context);

            var service = new ActorService(context);


            //Act
            var result = service.Delete(x);


            //Assert
            Assert.True(result);

        }



    }
}

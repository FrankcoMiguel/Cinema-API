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
    public class DirectorServiceTests
    {




        private void SeedDirectors(CinemaDbContext context)
        {

            var Directors = new[]
            {

                new Director {DirectorId = 1, FirstName = "Chirstopher", LastName = "Nolan", Age = 48, Rating ="9.4/10"},
                new Director {DirectorId = 2, FirstName = "Clint", LastName = "Eastwood", Age = 67, Rating ="7.3/10"},
                new Director {DirectorId = 3, FirstName = "Quentin", LastName = "Tarantino", Age = 51, Rating ="9.3/10"}

            };

            context.Director.AddRange(Directors);
            context.SaveChanges();

        }

        [Fact]
        public void ADD_ShouldReturnDirectorAdded()
        {

            //Arrange
            int x = 4;
            var director = new Director() { DirectorId = x, FirstName = "James", LastName = "Cameron", Age = 58, Rating = "9.6/10" };
            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase(databaseName: "ADD_ShouldReturnDirectorAdded")
                .Options;

            var context = new CinemaDbContext(options);

            SeedDirectors(context);

            var service = new DirectorService(context);

            //Act
            var result = service.Add(director);


            //Assert
            Assert.True(result);

        }


        [Fact]
        public void GET_ShouldReturnDirectorById2()
        {

            //Arrange
            int x = 2;
            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase(databaseName: "GET_ShouldReturnDirectorById2")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            var context = new CinemaDbContext(options);

            SeedDirectors(context);

            var service = new DirectorService(context);

            //Act
            var result = service.Select(x);


            //Assert
            Assert.Equal(result.DirectorId, x);

        }

        [Fact]
        public void GETALL_ShouldReturnAllDirectors()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase(databaseName: "GETALL_ShouldReturnAllDirectors")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            var context = new CinemaDbContext(options);

            SeedDirectors(context);

            var service = new DirectorService(context);

            //Act
            var result = service.SelectAll().ToList();


            //Assert
            Assert.Equal(3, result.Count);




        }

        [Fact]
        public void UPDATE_ShouldReturnNewName()
        {


            //Arrange
            var x = 2;
            var Director = new Director { DirectorId = x, FirstName = "David", LastName = "Fincher", Age = 54, Rating = "7.9/10" };

            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase(databaseName: "UPDATE_ShouldReturnNewName")
                .Options;

            var context = new CinemaDbContext(options);

            SeedDirectors(context);

            var service = new DirectorService(context);

            //Act
            var result = service.Update(x, Director);


            //Assert
            Assert.Equal(result.FirstName, Director.FirstName);

        } 

        [Fact]
        public void DELETE_ShouldReturnOneDirectorLess()
        {

            //Arrange
            int x = 2;
            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase(databaseName: "DELETE_ShouldReturnOneDirectorLess")
                .Options;


            var context = new CinemaDbContext(options);

            SeedDirectors(context);

            var service = new DirectorService(context);


            //Act
            var result = service.Delete(x);


            //Assert
            Assert.True(result);

        }



    }
}

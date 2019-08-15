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
    public class FilmServiceTests
    {




        private void SeedFilms(CinemaDbContext context)
        {

            var films = new[]
            {

                new Film {FilmId = 1, Title = "Godzilla", Description = "A big monster of monsters", Year = 2019, Duration ="2h 46min", Genre = "Fiction", Rating = "8.6/10" },
                new Film {FilmId = 2, Title = "Wonder Woman", Description = "A mistic woman has amazing superpowers", Year = 2016, Duration ="2h 21min", Genre = "Comics", Rating = "7.2/10" },
                new Film {FilmId = 3, Title = "Austin Powers", Description = "The super agent Austin Powers is involved in the President murder", Year = 2020, Duration ="3h 40min", Genre = "Action/Comedia", Rating = "8.4/10" }




            };

            context.Film.AddRange(films);
            context.SaveChanges();

        }

        [Fact]
        public void ADD_ShouldReturnFilmAdded()
        {

            //Arrange
            int x = 4;
            var film = new Film() { FilmId = x, Title = "Pain and Gain", Description = "Three bodybuilder will do anything to become rich", Year = 2014, Duration = "2h 10min", Genre = "Action/Drama", Rating = "8.1/10" };
            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase(databaseName: "ADD_ShouldReturnFilmAdded")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            var context = new CinemaDbContext(options);

            SeedFilms(context);

            var service = new FilmService(context);

            //Act
            var result = service.Add(film);


            //Assert
            Assert.Equal(result.Title, film.Title);

        }


        [Fact]
        public void GET_ShouldReturnFilmById3()
        {

            //Arrange
            int x = 3;
            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase(databaseName: "GET_ShouldReturnFilmById3")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            var context = new CinemaDbContext(options);

            SeedFilms(context);

            var service = new FilmService(context);

            //Act
            var result = service.Select(x);


            //Assert
            Assert.Equal(result.FilmId, x);

        }

        [Fact]
        public void GETALL_ShouldReturnAllFilms()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase(databaseName: "GETALL_ShouldReturnAllFilms")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            var context = new CinemaDbContext(options);

            SeedFilms(context);

            var service = new FilmService(context);

            //Act
            var result = service.SelectAll().ToList();


            //Assert
            Assert.Equal(3, result.Count);




        }

        [Fact]
        public void UPDATE_ShouldReturnNewName()
        {


            //Arrange
            var x = 1;
            var Film = new Film { FilmId = x, Title = "The Wolf of Wall Street", Description = "Jordan Befolrt is the best broker of Wall Street", Year = 2012, Duration = "2h 54min", Genre = "Drama", Rating = "9.2/10" };

            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase(databaseName: "UPDATE_ShouldReturnNewName")
                .Options;

            var context = new CinemaDbContext(options);

            SeedFilms(context);

            var service = new FilmService(context);

            //Act
            var result = service.Update(x, Film);


            //Assert
            Assert.True(result);

        } 

        [Fact]
        public void DELETE_ShouldReturnOneFilmLess()
        {

            //Arrange
            int x = 2;
            int i = 3 - 1; // We got three(3) objects into the db, then we remove one(1) of them.
            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase(databaseName: "DELETE_ShouldReturnOneFilmLess")
                .Options;


            var context = new CinemaDbContext(options);

            SeedFilms(context);

            var service = new FilmService(context);


            //Act
            var result = service.Delete(x);


            //Assert
            Assert.Equal(i, result.ToList().Count);

        }



    }
}

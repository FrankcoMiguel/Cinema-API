using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IFilmService
    {
        //POST
        bool Add(Film film);
        //GET
        Film Select(int id);
        //GET
        IEnumerable<Film> SelectAll();
        //PUT
        bool Update(int id, Film film);
        // DELETE
        bool Delete(int id);

    }

    public class FilmService : IFilmService
    {

        private readonly CinemaDbContext _cinemaDbContext;

        public FilmService(CinemaDbContext cinemaDbContext)
        {

            _cinemaDbContext = cinemaDbContext;

        }

        public bool Add(Film film)
        {

            try
            {

                _cinemaDbContext.Add(film);
                _cinemaDbContext.SaveChanges();

            }
            catch (System.Exception)
            {

                return false;

            }

            return true;

        }

        public Film Select(int id)
        {

            var filmFound = new Film();

            try
            {

                filmFound = _cinemaDbContext.Film.Single(x => x.FilmId == id);

            }
            catch (System.Exception e)
            {

                Console.WriteLine("Error caused by", e);

            }

            return filmFound;

        }

        public IEnumerable<Film> SelectAll()
        {

            var allFilms = new List<Film>();

            try
            {

                allFilms = _cinemaDbContext.Film.ToList();

            }
            catch (System.Exception e)
            {

                Console.WriteLine("Error caused by", e);

            }

            return allFilms;

        }

        public bool Update(int id, Film newFilm)
        {

            try
            {

                var actualFilm = _cinemaDbContext.Film.Single(x => x.FilmId == id);

                actualFilm.Title = newFilm.Title;
                actualFilm.Description = newFilm.Description;
                actualFilm.Year = newFilm.Year;
                actualFilm.Genre = newFilm.Genre;
                actualFilm.Duration = newFilm.Duration;
                actualFilm.Rating = newFilm.Rating;

                _cinemaDbContext.Update(actualFilm);
                _cinemaDbContext.SaveChanges();

            }
            catch (System.Exception)
            {

                return false;

            }

            return true;


        }

        public bool Delete(int id)
        {

            try
            {

                _cinemaDbContext.Remove(new Film { FilmId = id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _cinemaDbContext.SaveChanges();


            }
            catch (System.Exception)
            {

                return false;

            }

            return true;

        }

    }
}

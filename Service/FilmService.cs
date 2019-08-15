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
        Film Add(Film film);
        //GET
        Film Select(int id);
        //GET
        IEnumerable<Film> SelectAll();
        //PUT
        bool Update(int id, Film film);
        // DELETE
        IEnumerable<Film> Delete(int id);

    }

    public class FilmService : IFilmService
    {

        private readonly CinemaDbContext _cinemaDbContext;

        public FilmService(CinemaDbContext cinemaDbContext)
        {

            _cinemaDbContext = cinemaDbContext;

        }

        public Film Add(Film film)
        {

            try
            {

                _cinemaDbContext.Add(film);
                _cinemaDbContext.SaveChanges();
                return film;

            }
            catch (System.Exception e)
            {

                throw e;

            }

            

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

        public IEnumerable<Film> Delete(int id)
        {

            try
            {
                Film film = _cinemaDbContext.Film.Single(x => x.FilmId == id);
                _cinemaDbContext.Remove(film).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _cinemaDbContext.SaveChanges();

                return _cinemaDbContext.Film.ToList();


            }
            catch (System.Exception e)
            {

                throw e;

            }



        }

    }
}

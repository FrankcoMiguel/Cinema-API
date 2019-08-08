
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Service
{
    public interface IFilmService
    {
        //POST
        Film Add_FakeFilm(Film fakeFilm);
        //GET
        Film Select_FakeFilm(int id);
        //GET
        IEnumerable<Film> Select_All_FakeFilms();
        //PUT
        bool Update_FakeFilm(int id, Film film);
        // DELETE
        bool Delete_FakeFilm(int id);

    }

    public class FilmServiceTests : IFilmService
    {

        private readonly List<Film> _fakeFilms;

        public FilmServiceTests()
        {

            _fakeFilms = new List<Film>()
                {

                    new Film() {FilmId = 1, Title = "King Kong",
                        Description = "Un mono gigante en las calles de New York",
                        Duration = "2h 10 min", Genre = "Fiction", Year = 2011,
                        Rating = "7.9/10" },


                     new Film() {FilmId = 1, Title = "Mission Imposbile",
                        Description = "Ethan Hunt se encuentra en su mission mas emocionante",
                        Duration = "2h 34 min", Genre = "Drama", Year = 2013,
                        Rating = "8.3/10" }


                };

        }
        
        public Film Add_FakeFilm(Film fakeFilm)
        {

             Random rnd = new Random();
             fakeFilm.FilmId = rnd.Next(1, 500);
            _fakeFilms.Add(fakeFilm);

            return fakeFilm;
        }

        public Film Select_FakeFilm(int id)
        {

            return _fakeFilms.Where(x => x.FilmId == id).FirstOrDefault();

        }

        public IEnumerable<Film> Select_All_FakeFilms()
        {

            return _fakeFilms;

        }

        public bool Update_FakeFilm(int id, Film fakeFilm)
        {

            var existingFilm = _fakeFilms.Single(x => x.FilmId == id);

            existingFilm.Title = fakeFilm.Title;
            existingFilm.Description = fakeFilm.Description;
            existingFilm.Year = fakeFilm.Year;
            existingFilm.Genre = fakeFilm.Genre;
            existingFilm.Duration = fakeFilm.Duration;
            existingFilm.Rating = fakeFilm.Rating;

            _fakeFilms.Add(fakeFilm);

            return true;


        }

        public bool Delete_FakeFilm(int id)
        {

            var EmployeeExisting = _fakeFilms.First(x => x.FilmId == id);
            _fakeFilms.Remove(EmployeeExisting);
            return true;

        }

    }
}

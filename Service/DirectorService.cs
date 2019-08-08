using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public interface IDirectorService
    {
        //POST
        bool Add(Director Director);
        //GET
        Director Select(int id);
        //GET
        IEnumerable<Director> SelectAll();
        //PUT
        bool Update(int id, Director Director);
        // DELETE
        bool Delete(int id);

    }
    public class DirectorService : IDirectorService
    {

        private readonly CinemaDbContext _cinemaDbContext;

        public DirectorService(CinemaDbContext cinemaDbContext)
        {

            _cinemaDbContext = cinemaDbContext;

        }

        public bool Add(Director Director)
        {

            try
            {

                _cinemaDbContext.Add(Director);
                _cinemaDbContext.SaveChanges();

            }
            catch (System.Exception)
            {

                return false;

            }

            return true;

        }

        public Director Select(int id)
        {

            var DirectorFound = new Director();

            try
            {

                DirectorFound = _cinemaDbContext.Director.Single(x => x.DirectorId == id);

            }
            catch (System.Exception e)
            {

                Console.WriteLine("Error caused by", e);

            }

            return DirectorFound;

        }

        public IEnumerable<Director> SelectAll()
        {

            var allDirectors = new List<Director>();

            try
            {

                allDirectors = _cinemaDbContext.Director.ToList();

            }
            catch (System.Exception e)
            {

                Console.WriteLine("Error caused by", e);

            }

            return allDirectors;

        }

        public bool Update(int id, Director newDirector)
        {

            try
            {

                var actualDirector = _cinemaDbContext.Director.Single(x => x.DirectorId == id);

                actualDirector.FirstName = newDirector.FirstName;
                actualDirector.LastName = newDirector.LastName;
                actualDirector.Age = newDirector.Age;
                actualDirector.Rating = newDirector.Rating;

                _cinemaDbContext.Update(actualDirector);
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

                _cinemaDbContext.Remove(new Director { DirectorId = id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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

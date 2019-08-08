
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Service
{
    public interface IDirectorService
    {
        //POST
        Director Add_FakeDirector(Director fakeDirector);
        //GET
        Director Select_FakeDirector(int id);
        //GET
        IEnumerable<Director> Select_All_FakeDirectors();
        //PUT
        bool Update_FakeDirector(int id, Director Director);
        // DELETE
        bool Delete_FakeDirector(int id);

    }

    public class DirectorServiceFake : IDirectorService
    {

        private readonly List<Director> _fakeDirectors;

        public DirectorServiceFake()
        {

            _fakeDirectors = new List<Director>()
                {

                    new Director() {DirectorId = 1, FirstName = "Steven",
                        LastName = "Spielberg", Age = 56, Rating = "9.6/10"},

                    new Director() {DirectorId = 1, FirstName = "Christopher",
                        LastName = "Nolan", Age = 49, Rating = "9.2/10"},


                };

        }
        

        public Director Add_FakeDirector(Director fakeDirector)
        {

             Random rnd = new Random();
             fakeDirector.DirectorId = rnd.Next(1, 200);
            _fakeDirectors.Add(fakeDirector);

            return fakeDirector;
        }

        public bool Delete_FakeDirector(int id)
        {
            var DirectorExisting = _fakeDirectors.First(x => x.DirectorId == id);
            _fakeDirectors.Remove(DirectorExisting);
            return true;
        }

        public IEnumerable<Director> Select_All_FakeDirectors()
        {
            return _fakeDirectors;
        }

        public Director Select_FakeDirector(int id)
        {

            return _fakeDirectors.Where(x => x.DirectorId == id).FirstOrDefault();

        }

        public bool Update_FakeDirector(int id, Director fakeDirector)
        {

            var DirectorExisting = _fakeDirectors.First(x => x.DirectorId == id);

            DirectorExisting.FirstName = fakeDirector.FirstName;
            DirectorExisting.LastName = fakeDirector.LastName;
            DirectorExisting.Age = fakeDirector.Age;
            DirectorExisting.Rating = fakeDirector.Rating;

            return true;

        }

    }

}


using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Service
{
    public interface IActorService
    {
        //POST
        Actor Add_FakeActor(Actor fakeActor);
        //GET
        Actor Select_FakeActor(int id);
        //GET
        IEnumerable<Actor> Select_All_FakeActors();
        //PUT
        bool Update_FakeActor(int id, Actor Actor);
        // DELETE
        bool Delete_FakeActor(int id);

    }

    public class ActorServiceTests : IActorService
    {

        private readonly List<Actor> _fakeActors;

        public ActorServiceTests()
        {

            _fakeActors = new List<Actor>()
                {

                    new Actor() {ActorId = 1, FirstName = "Keanu",
                        LastName = "Reeves", Age = 52, Rating = "10/10"},

                    new Actor() {ActorId = 1, FirstName = "Matt",
                        LastName = "Damon", Age = 48, Rating = "9.6/10"},


                };

        }
        

        public Actor Add_FakeActor(Actor fakeActor)
        {

             Random rnd = new Random();
             fakeActor.ActorId = rnd.Next(1, 200);
            _fakeActors.Add(fakeActor);

            return fakeActor;
        }

        public bool Delete_FakeActor(int id)
        {
            var ActorExisting = _fakeActors.First(x => x.ActorId == id);
            _fakeActors.Remove(ActorExisting);
            return true;
        }

        public IEnumerable<Actor> Select_All_FakeActors()
        {
            return _fakeActors;
        }

        public Actor Select_FakeActor(int id)
        {

            return _fakeActors.Where(x => x.ActorId == id).FirstOrDefault();

        }

        public bool Update_FakeActor(int id, Actor fakeActor)
        {

            var ActorExisting = _fakeActors.First(x => x.ActorId == id);

            ActorExisting.FirstName = fakeActor.FirstName;
            ActorExisting.LastName = fakeActor.LastName;
            ActorExisting.Age = fakeActor.Age;
            ActorExisting.Rating = fakeActor.Rating;

            return true;

        }
    }
}

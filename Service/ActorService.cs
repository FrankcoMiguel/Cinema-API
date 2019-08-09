using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IActorService
    {
        //POST
        Actor Add(Actor actor);
        //GET
        Actor Select(int id);
        //GET
        IEnumerable<Actor> SelectAll();
        //PUT
        Actor Update(int id, Actor actor);
        // DELETE
        bool Delete(int id);

    }
    public class ActorService : IActorService
    {

        private readonly CinemaDbContext _cinemaDbContext;

        public ActorService(CinemaDbContext cinemaDbContext)
        {

            _cinemaDbContext = cinemaDbContext;

        }

        public Actor Add(Actor actor)
        {

            try
            {

                _cinemaDbContext.Add(actor);
                _cinemaDbContext.SaveChanges();

            }
            catch (System.Exception e)
            {

                throw e;

            }

            return actor;

        }

        public Actor Select(int id)
        {

            var actorFound = new Actor();

            try
            {

                actorFound = _cinemaDbContext.Actor.Single(x => x.ActorId == id);

            }
            catch (System.Exception e)
            {

                Console.WriteLine("Error caused by", e);

            }

            return actorFound;

        }

        public IEnumerable<Actor> SelectAll()
        {

            var allActors = new List<Actor>();

            try
            {

                allActors = _cinemaDbContext.Actor.ToList();

            }
            catch (System.Exception e)
            {

                Console.WriteLine("Error caused by", e);

            }

            return allActors;

        }

        public Actor Update(int id, Actor newActor)
        {

            try
            {

                var actualActor = _cinemaDbContext.Actor.Single(x => x.ActorId == id);

                actualActor.FirstName = newActor.FirstName;
                actualActor.LastName = newActor.LastName;
                actualActor.Age = newActor.Age;
                actualActor.Gender = newActor.Gender;
                actualActor.Rating = newActor.Rating;


                _cinemaDbContext.Update(actualActor);
                _cinemaDbContext.SaveChanges();

                return actualActor;

            }
            catch (System.Exception e)
            {

                throw e;

            }

     


        }

        public bool Delete(int id)
        {

            Actor actorRemove = new Actor { ActorId = id };

            try
            {
                _cinemaDbContext.Actor.Remove(actorRemove);
                _cinemaDbContext.SaveChanges();


                return true;

            }
            catch (System.Exception e)
            {

                throw e;



            }


        }

    }
}

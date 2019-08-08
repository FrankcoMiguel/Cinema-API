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
        bool Add(Actor actor);
        //GET
        Actor Select(int id);
        //GET
        IEnumerable<Actor> SelectAll();
        //PUT
        bool Update(int id, Actor actor);
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

        public bool Add(Actor actor)
        {

            try
            {

                _cinemaDbContext.Add(actor);
                _cinemaDbContext.SaveChanges();

            }
            catch (System.Exception)
            {

                return false;

            }

            return true;

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

        public bool Update(int id, Actor newActor)
        {

            try
            {

                var actualActor = _cinemaDbContext.Actor.Single(x => x.ActorId == id);

                actualActor.FirstName = newActor.FirstName;
                actualActor.LastName = newActor.LastName;
                actualActor.Age = newActor.Age;
                actualActor.Films = newActor.Films;
                actualActor.Rating = newActor.Rating;


                _cinemaDbContext.Update(actualActor);
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

                _cinemaDbContext.Remove(new Actor { ActorId = id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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

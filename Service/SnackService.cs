using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public interface ISnackService
    {
        //POST
        bool Add(Snack snack);
        //GET
        Snack Select(int id);
        //GET
        IEnumerable<Snack> SelectAll();
        //PUT
        Snack Update(int id, Snack snack);
        // DELETE
        bool Delete(int id);

    }
    public class SnackService : ISnackService
    {

        private readonly CinemaDbContext _cinemaDbContext;

        public SnackService(CinemaDbContext cinemaDbContext)
        {

            _cinemaDbContext = cinemaDbContext;

        }

        public bool Add(Snack snack)
        {

            try
            {

                _cinemaDbContext.Add(snack);
                _cinemaDbContext.SaveChanges();

            }
            catch (System.Exception)
            {

                return false;

            }

            return true;

        }

        public Snack Select(int id)
        {

            var snackFound = new Snack();

            try
            {

                snackFound = _cinemaDbContext.Snack.Single(x => x.SnackId == id);

            }
            catch (System.Exception e)
            {

                Console.WriteLine("Error caused by", e);

            }

            return snackFound;

        }

        public IEnumerable<Snack> SelectAll()
        {

            var allSnacks = new List<Snack>();

            try
            {

                allSnacks = _cinemaDbContext.Snack.ToList();

            }
            catch (System.Exception e)
            {

                Console.WriteLine("Error caused by", e);

            }

            return allSnacks;

        }

        public Snack Update(int id, Snack newSnack)
        {

            try
            {

                var actualSnack = _cinemaDbContext.Snack.Single(x => x.SnackId == id);

                actualSnack.Name = newSnack.Name;
                actualSnack.Size = newSnack.Size;
                actualSnack.Cost = newSnack.Cost;



                _cinemaDbContext.Update(actualSnack);
                _cinemaDbContext.SaveChanges();

                return actualSnack;

            }
            catch (System.Exception e)
            {

                throw e;

            }

            


        }

        public bool Delete(int id)
        {

            try
            {
                Snack snack = _cinemaDbContext.Snack.Single(x => x.SnackId == id);
                _cinemaDbContext.Remove(snack).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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
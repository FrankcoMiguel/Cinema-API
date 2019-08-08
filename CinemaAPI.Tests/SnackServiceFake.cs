
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Service
{
    public interface ISnackService
    {
        //POST
        Snack Add_FakeSnack(Snack fakeSnack);
        //GET
        Snack Select_FakeSnack(int id);
        //GET
        IEnumerable<Snack> Select_All_FakeSnacks();
        //PUT
        bool Update_FakeSnack(int id, Snack Snack);
        // DELETE
        bool Delete_FakeSnack(int id);

    }

    public class SnackServiceFake : ISnackService
    {

        private readonly List<Snack> _fakeSnacks;

        public SnackServiceFake()
        {

            _fakeSnacks = new List<Snack>()
                {

                    new Snack() {SnackId = 1, Name = "Pop Corn", Size = "Small", Cost = 7.99},
                    new Snack() {SnackId = 2, Name = "Dr Pepper", Size = "Large", Cost = 5.80},
                    new Snack() {SnackId = 3, Name = "Nachos Club + Coke", Size = "Small", Cost = 12.99}

                };

        }
        

        public Snack Add_FakeSnack(Snack fakeSnack)
        {

             Random rnd = new Random();
             fakeSnack.SnackId = rnd.Next(1, 200);
            _fakeSnacks.Add(fakeSnack);

            return fakeSnack;
        }

        public bool Delete_FakeSnack(int id)
        {
            var SnackExisting = _fakeSnacks.First(x => x.SnackId == id);
            _fakeSnacks.Remove(SnackExisting);
            return true;
        }

        public IEnumerable<Snack> Select_All_FakeSnacks()
        {
            return _fakeSnacks;
        }

        public Snack Select_FakeSnack(int id)
        {

            return _fakeSnacks.Where(x => x.SnackId == id).FirstOrDefault();

        }

        public bool Update_FakeSnack(int id, Snack fakeSnack)
        {

            var SnackExisting = _fakeSnacks.First(x => x.SnackId == id);

            SnackExisting.Name = fakeSnack.Name;
            SnackExisting.Size = fakeSnack.Size;
            SnackExisting.Cost = fakeSnack.Cost;

            return true;

        }
    }
}


using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Service
{
    public interface IEmployeeService
    {
        //POST
        Employee Add_FakeEmployee(Employee fakeEmployee);
        //GET
        Employee Select_FakeEmployee(int id);
        //GET
        IEnumerable<Employee> Select_All_FakeEmployees();
        //PUT
        bool Update_FakeEmployee(int id, Employee Employee);
        // DELETE
        bool Delete_FakeEmployee(int id);

    }

    public class EmployeeServiceFake : IEmployeeService
    {

        private readonly List<Employee> _fakeEmployees;

        public EmployeeServiceFake()
        {

            _fakeEmployees = new List<Employee>()
                {

                    new Employee() {EmployeeId = 1, FirstName = "Juan",
                        LastName = "Heyaime", Age = 31},

                    new Employee() {EmployeeId = 1, FirstName = "Mark",
                        LastName = "Johnson", Age = 24},


                };

        }
        

        public Employee Add_FakeEmployee(Employee fakeEmployee)
        {

             Random rnd = new Random();
             fakeEmployee.EmployeeId = rnd.Next(1, 200);
            _fakeEmployees.Add(fakeEmployee);

            return fakeEmployee;
        }

        public bool Delete_FakeEmployee(int id)
        {
            var EmployeeExisting = _fakeEmployees.First(x => x.EmployeeId == id);
            _fakeEmployees.Remove(EmployeeExisting);
            return true;
        }

        public IEnumerable<Employee> Select_All_FakeEmployees()
        {
            return _fakeEmployees;
        }

        public Employee Select_FakeEmployee(int id)
        {

            return _fakeEmployees.Where(x => x.EmployeeId == id).FirstOrDefault();

        }

        public bool Update_FakeEmployee(int id, Employee fakeEmployee)
        {

            var EmployeeExisting = _fakeEmployees.First(x => x.EmployeeId == id);

            EmployeeExisting.FirstName = fakeEmployee.FirstName;
            EmployeeExisting.LastName = fakeEmployee.LastName;
            EmployeeExisting.Age = fakeEmployee.Age;

            return true;

        }
    }
}

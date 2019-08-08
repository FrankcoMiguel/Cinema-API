using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public interface IEmployeeService
    {
        //POST
        bool Add(Employee employee);
        //GET
        Employee Select(int id);
        //GET
        IEnumerable<Employee> SelectAll();
        //PUT
        bool Update(int id, Employee employee);
        // DELETE
        bool Delete(int id);

    }
    public class EmployeeService : IEmployeeService
    {

        private readonly CinemaDbContext _cinemaDbContext;

        public EmployeeService(CinemaDbContext cinemaDbContext)
        {

            _cinemaDbContext = cinemaDbContext;

        }

        public bool Add(Employee employee)
        {

            try
            {

                _cinemaDbContext.Add(employee);
                _cinemaDbContext.SaveChanges();

            }
            catch (System.Exception)
            {

                return false;

            }

            return true;

        }

        public Employee Select(int id)
        {

            var employeeFound = new Employee();

            try
            {

                employeeFound = _cinemaDbContext.Employee.Single(x => x.EmployeeId == id);

            }
            catch (System.Exception e)
            {

                Console.WriteLine("Error caused by", e);

            }

            return employeeFound;

        }

        public IEnumerable<Employee> SelectAll()
        {

            var allEmployees = new List<Employee>();

            try
            {

                allEmployees = _cinemaDbContext.Employee.ToList();

            }
            catch (System.Exception e)
            {

                Console.WriteLine("Error caused by", e);

            }

            return allEmployees;

        }

        public bool Update(int id, Employee newEmployee)
        {

            try
            {

                var actualEmployee = _cinemaDbContext.Employee.Single(x => x.EmployeeId == id);

                actualEmployee.FirstName = newEmployee.FirstName;
                actualEmployee.LastName = newEmployee.LastName;
                actualEmployee.Age = newEmployee.Age;




                _cinemaDbContext.Update(actualEmployee);
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

                _cinemaDbContext.Remove(new Employee { EmployeeId = id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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
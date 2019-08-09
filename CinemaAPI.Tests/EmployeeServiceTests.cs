using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CinemaAPI.Tests
{
    public class EmployeeServiceTests
    {




        private void SeedEmployees(CinemaDbContext context)
        {

            var Employees = new[]
            {

                new Employee {EmployeeId = 1, FirstName = "Mike", LastName = "Blanchet", Age = 24 },
                new Employee {EmployeeId = 2, FirstName = "Juliett", LastName = "Mars", Age = 19 },
                new Employee {EmployeeId = 3, FirstName = "Albert", LastName = "Jackson", Age = 32 },
                new Employee {EmployeeId = 4, FirstName = "Jean Carlos", LastName = "Arnaud", Age = 21 },
                new Employee {EmployeeId = 5, FirstName = "Joaquin", LastName = "Phoenix", Age = 29 }

            };

            context.Employee.AddRange(Employees);
            context.SaveChanges();

        }

        [Fact]
        public void ADD_ShouldReturnEmployeeAdded()
        {

            //Arrange
            int x = 6;
            var employee = new Employee() { EmployeeId = x, FirstName = "Miguel", LastName = "Cruz", Age = 26 };
            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase(databaseName: "ADD_ShouldReturnEmployeeAdded")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            var context = new CinemaDbContext(options);

            SeedEmployees(context);

            var service = new EmployeeService(context);

            //Act
            var result = service.Add(employee);


            //Assert
            Assert.True(result);

        }


        [Fact]
        public void GET_ShouldReturnEmployeeById2()
        {

            //Arrange
            int x = 4;
            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase(databaseName: "GET_ShouldReturnEmployeeById4")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            var context = new CinemaDbContext(options);

            SeedEmployees(context);

            var service = new EmployeeService(context);

            //Act
            var result = service.Select(x);


            //Assert
            Assert.Equal(result.EmployeeId, x);

        }

        [Fact]
        public void GETALL_ShouldReturnAllEmployees()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase(databaseName: "GETALL_ShouldReturnAllEmployees")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            var context = new CinemaDbContext(options);

            SeedEmployees(context);

            var service = new EmployeeService(context);

            //Act
            var result = service.SelectAll().ToList();


            //Assert
            Assert.Equal(5, result.Count);




        }

        [Fact]
        public void UPDATE_ShouldReturnNewLastName()
        {


            //Arrange
            var x = 1;
            var employee = new Employee { EmployeeId = x, FirstName = "Pablo", LastName = "Almonte", Age = 18 };

            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase(databaseName: "UPDATE_ShouldReturnNewName")
                .Options;

            var context = new CinemaDbContext(options);

            SeedEmployees(context);

            var service = new EmployeeService(context);

            //Act
            var result = service.Update(x, employee);


            //Assert
            Assert.Equal(result.LastName, employee.LastName);

        } 

        [Fact]
        public void DELETE_ShouldReturnOneEmployeeLess()
        {

            //Arrange
            int x = 4;
            var options = new DbContextOptionsBuilder<CinemaDbContext>()
                .UseInMemoryDatabase(databaseName: "DELETE_ShouldReturnOneEmployeeLess")
                .Options;


            var context = new CinemaDbContext(options);

            SeedEmployees(context);

            var service = new EmployeeService(context);


            //Act
            var result = service.Delete(x);


            //Assert
            Assert.Equal(4,result.ToList().Count);

        }



    }
}

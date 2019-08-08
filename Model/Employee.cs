using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Employee
    {

        public Employee()
        {

           // Role = new HashSet<Staff>();

        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }


        //public Staff Role { get; set; }

        



    }
}

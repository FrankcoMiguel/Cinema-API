using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Employee
    {

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int StaffId { get; set; }
        public Staff Title { get; set; }

    }
}

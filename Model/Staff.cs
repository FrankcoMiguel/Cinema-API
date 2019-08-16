using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Staff
    {

        public int StaffId { get; set; }
        public string Title { get; set; }
        public double Salary { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}

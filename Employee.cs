using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASHTest.Models
{
    public class Employee
    {
        public int EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int AddressID { get; set; }
        public decimal PayPerHour { get; set; }
    }
}
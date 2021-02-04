using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASHTest.Models
{
    public class Manager
    {
        public int ManagerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int AddressID { get; set; }
        public decimal AnnualSalary { get; set; }

        public decimal? MaxExpenseAccount { get; set; }
    }
}
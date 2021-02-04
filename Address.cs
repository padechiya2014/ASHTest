using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASHTest.Models
{
    public class Address
    {
        public int AddressID { get; set; }

        public int EmpID { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }

        public string State { get; set; }
        public string City { get; set; }

        public int ZipCode { get; set; }
    }
}
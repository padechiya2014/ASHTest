using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASHTest.Models
{
    public class Worker
    {
        public IList<Employee> lstEmployee;
        public IList<Supervisor> lstSupervisor;
        public IList<Manager> lstManager;
    }
}
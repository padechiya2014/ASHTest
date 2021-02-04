using ASHTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ASHTest.Controllers
{
    public class WorkerController : ApiController
    {

        [HttpGet]
        public IList<Employee> GetAllEmployees()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=.\SQLSERVER2008R2;Database=DBCompany;User ID=sa;Password=xyz@1234;";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * from Employee";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            List<Employee> empList = new List<Employee>();
            while (reader.Read())
            {
                Employee emp = new Employee();
                emp.EmpID = Convert.ToInt32(reader.GetValue(0));
                emp.FirstName = reader.GetValue(1).ToString();
                emp.LastName = reader.GetValue(2).ToString();
                empList.Add(emp);
            }
            myConnection.Close();
            return empList;    
        }

        [HttpGet]
        public IList<Supervisor> GetAllSupervisors()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=.\SQLSERVER2008R2;Database=DBCompany;User ID=sa;Password=xyz@1234;";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * from Supervisor";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            List<Supervisor> supervisorList = new List<Supervisor>();
            while (reader.Read())
            {
                Supervisor Supervisor = new Supervisor();
                Supervisor.SupervisorID = Convert.ToInt32(reader.GetValue(0));
                Supervisor.FirstName = reader.GetValue(1).ToString();
                Supervisor.LastName = reader.GetValue(2).ToString();
                supervisorList.Add(Supervisor);
            }
            myConnection.Close();
            return supervisorList;
        }


        [HttpGet]
        public IList<Manager> GetAllManagers()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=.\SQLSERVER2008R2;Database=DBCompany;User ID=sa;Password=xyz@1234;";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * from Manager";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            List<Manager> managerList = new List<Manager>();
            while (reader.Read())
            {
                Manager Manager = new Manager();
                Manager.ManagerID = Convert.ToInt32(reader.GetValue(0));
                Manager.FirstName = reader.GetValue(1).ToString();
                Manager.LastName = reader.GetValue(2).ToString();
                managerList.Add(Manager);
            }
            myConnection.Close();
            return managerList;
        }

        [HttpGet]
        [ActionName("GetAllWorkers")]
        public Worker Get()
        {

            IList<Employee> lstEmployee = GetAllEmployees();
            IList<Supervisor> lstSupervisor = GetAllSupervisors();
            IList<Manager> lstManager = GetAllManagers();

            Worker worker = new Worker();
            worker.lstEmployee = lstEmployee;
            worker.lstSupervisor = lstSupervisor;
            worker.lstManager = lstManager;

            return worker;
            
        }

       
        public void AddWorker(string workerType) 
        {
            string caseSwitch = workerType;

            switch (caseSwitch)
            {
                case "Employee":
                    AddEmployee();
                    break;
                case "Supervisor":
                    AddSupervisor();
                    break;
                case "Manager":
                    AddManager();
                    break;
                default:
                    Console.WriteLine("Please enter valid worker types from the following: Employee, Supervisor, Manager");
                    break;
            }

         
        }

        [HttpPost]
        public void AddEmployee()
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=.\SQLSERVER2008R2;Database=DBCompany;User ID=sa;Password=xyz@1234;";

            // Id is identity auto generated in SQL
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO Employee (FirstName,LastName,AddressID,PayPerHour) Values (@FirstName,@LastName" +
                "@AddressID, @PayPerHour)";
            sqlCmd.Connection = myConnection;

            sqlCmd.Parameters.AddWithValue("@FirstName", "TestFName");
            sqlCmd.Parameters.AddWithValue("@LastName", "TestLName");
            sqlCmd.Parameters.AddWithValue("@AddressID", AddAddressForNewWorker());
            sqlCmd.Parameters.AddWithValue("@PayPerHour", 40);
            myConnection.Open();
            int rowInserted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }


        [HttpPost]
        public void AddSupervisor()
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=.\SQLSERVER2008R2;Database=DBCompany;User ID=sa;Password=xyz@1234;";

            // Id is identity auto generated in SQL
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO Supervisor (FirstName,LastName,AddressID,AnnualSalary) Values (@FirstName,@LastName" +
                "@AddressID, @AnnualSalary)";
            sqlCmd.Connection = myConnection;

            sqlCmd.Parameters.AddWithValue("@FirstName", "TestFName");
            sqlCmd.Parameters.AddWithValue("@LastName", "TestLName");
            sqlCmd.Parameters.AddWithValue("@AddressID", AddAddressForNewWorker());
            sqlCmd.Parameters.AddWithValue("@AnnualSalary", 40000);
            myConnection.Open();
            int rowInserted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }



        [HttpPost]
        public void AddManager()
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=.\SQLSERVER2008R2;Database=DBCompany;User ID=sa;Password=xyz@1234;";

            // Id is identity auto generated in SQL
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO Manager (FirstName,LastName,AddressID,AnnualSalary,MaxExpenseAccount) Values (@FirstName,@LastName" +
                "@AddressID, @AnnualSalary,@MaxExpenseAccount)";
            sqlCmd.Connection = myConnection;

            sqlCmd.Parameters.AddWithValue("@FirstName", "TestFName");
            sqlCmd.Parameters.AddWithValue("@LastName", "TestLName");
            sqlCmd.Parameters.AddWithValue("@AddressID", AddAddressForNewWorker());
            sqlCmd.Parameters.AddWithValue("@AnnualSalary", 70000);
            sqlCmd.Parameters.AddWithValue("@MaxExpenseAccount", 10000);
            myConnection.Open();
            int rowInserted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }

        public int AddAddressForNewWorker()
        {
            // Some logic to add address for a new worker based on Employee/Supervisor/Manager ID and Address ID
            // and return the newly generated AddressID

            return 0;

        }
    }
}
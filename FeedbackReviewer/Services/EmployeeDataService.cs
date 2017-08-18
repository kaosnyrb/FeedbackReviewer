using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FeedbackReviewer.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace FeedbackReviewer.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        public Employee AddEmployee(Employee employee)
        {
            using (var myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FeedbackReviewerDB"].ConnectionString))
            {
                myConnection.Open();
                string sqlCommand = @"INSERT INTO [Employees]([Id],[Name]) VALUES(@Id,@Name)";
                using (SqlCommand command = new SqlCommand(sqlCommand, myConnection))
                {
                    command.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.UniqueIdentifier) { Value = employee.EmployeeId });
                    command.Parameters.Add(new SqlParameter("Name", System.Data.SqlDbType.NVarChar) { Value = employee.Name});
                    command.ExecuteNonQuery();
                }
                myConnection.Close();
            }
            return employee;
        }

        public void DeleteEmployee(Guid employeeId)
        {
            using (var myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FeedbackReviewerDB"].ConnectionString))
            {
                myConnection.Open();
                string sqlCommand = @"DELETE FROM [Employees] WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(sqlCommand, myConnection))
                {
                    command.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.UniqueIdentifier) { Value = employeeId });
                    command.ExecuteNonQuery();
                }
                myConnection.Close();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            var employeeList = new List<Employee>();
            using (var myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FeedbackReviewerDB"].ConnectionString))
            {
                myConnection.Open();
                string sqlCommand = @"SELECT * FROM [Employees]";
                using (SqlCommand command = new SqlCommand(sqlCommand, myConnection))
                {
                    var myReader = command.ExecuteReader();
                    while (myReader.Read())
                    {
                        Employee temp = new Employee()
                        {
                            EmployeeId = Guid.Parse(myReader["Id"].ToString()),
                            Name = myReader["Name"].ToString()
                        };
                        employeeList.Add(temp);
                    }
                }
                myConnection.Close();
            }
            return employeeList;
        }

        public Employee GetEmployee(Guid employeeId)
        {
            Employee employee = null;
            using (var myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FeedbackReviewerDB"].ConnectionString))
            {
                myConnection.Open();
                string sqlCommand = @"SELECT * FROM [Employees] WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(sqlCommand, myConnection))
                {
                    command.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.UniqueIdentifier) { Value = employeeId });
                    var myReader = command.ExecuteReader();
                    while (myReader.Read())
                    {
                        employee = new Employee()
                        {
                            EmployeeId = Guid.Parse(myReader["Id"].ToString()),
                            Name = myReader["Name"].ToString()
                        };
                    }
                }
                myConnection.Close();
            }
            return employee;
        }

        public Employee UpdateEmployee(Guid employeeId, Employee employee)
        {
            using (var myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FeedbackReviewerDB"].ConnectionString))
            {
                myConnection.Open();
                string sqlCommand = @"UPDATE [Employees] SET [Name] = @Name WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(sqlCommand, myConnection))
                {
                    command.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.UniqueIdentifier) { Value = employee.EmployeeId });
                    command.Parameters.Add(new SqlParameter("Name", System.Data.SqlDbType.NVarChar) { Value = employee.Name });
                    command.ExecuteNonQuery();
                }
                myConnection.Close();
            }
            return employee;
        }
    }
}
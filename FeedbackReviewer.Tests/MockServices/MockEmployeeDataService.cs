using FeedbackReviewer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedbackReviewer.Models;

namespace FeedbackReviewer.Tests.MockServices
{
    class MockEmployeeDataService : IEmployeeDataService
    {

        public Dictionary<Guid, Employee> Employees;

        public MockEmployeeDataService()
        {
            Employees = new Dictionary<Guid, Employee>();
        }

        public Employee AddEmployee(Employee employee)
        {
            Employees.Add(employee.EmployeeId, employee);
            return employee;
        }

        public void DeleteEmployee(Guid employeeId)
        {
            Employees.Remove(employeeId);
        }

        public List<Employee> GetAllEmployees()
        {
            var returnlist = new List<Employee>();
            foreach(var key in Employees.Keys)
            {
                returnlist.Add(Employees[key]);
            }
            return returnlist;
        }

        public Employee GetEmployee(Guid employeeId)
        {
            return Employees[employeeId];
        }

        public Employee UpdateEmployee(Guid employeeId, Employee employee)
        {
            Employees[employeeId] = employee;
            return Employees[employeeId];
        }
    }
}

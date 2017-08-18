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

        private Dictionary<Guid, Employee> _employees;

        public MockEmployeeDataService()
        {
            _employees = new Dictionary<Guid, Employee>();
        }

        public Employee AddEmployee(Employee employee)
        {
            _employees.Add(employee.EmployeeId, employee);
            return employee;
        }

        public void DeleteEmployee(Guid employeeId)
        {
            _employees.Remove(employeeId);
        }

        public List<Employee> GetAllEmployees()
        {
            var returnlist = new List<Employee>();
            foreach(var key in _employees.Keys)
            {
                returnlist.Add(_employees[key]);
            }
            return returnlist;
        }

        public Employee GetEmployee(Guid employeeId)
        {
            return _employees[employeeId];
        }

        public Employee UpdateEmployee(Guid employeeId, Employee employee)
        {
            _employees[employeeId] = employee;
            return _employees[employeeId];
        }
    }
}

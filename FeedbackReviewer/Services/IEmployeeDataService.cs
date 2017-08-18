using FeedbackReviewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackReviewer.Services
{
    public interface IEmployeeDataService
    {
        List<Employee> GetAllEmployees();

        Employee GetEmployee(Guid employeeId);

        Employee AddEmployee(Employee employee);

        Employee UpdateEmployee(Guid employeeId, Employee employee);

        void DeleteEmployee(Guid employeeId);
    }
}

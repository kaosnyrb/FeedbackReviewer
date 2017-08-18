using FeedbackReviewer.Models;
using FeedbackReviewer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FeedbackReviewer.Controllers
{
    [RoutePrefix("api/employees")]
    public class EmployeesController : ApiController
    {
        public IEmployeeDataService _employeeDataService;

        public EmployeesController()
        {
            _employeeDataService = new EmployeeDataService();
        }

        [Route("")]
        [HttpGet]
        public List<Employee> GetEmployees()
        {
            return _employeeDataService.GetAllEmployees();
        }

        [Route("{EmployeeId:Guid}")]
        [HttpGet]
        public Employee Get(Guid EmployeeId)
        {
            return _employeeDataService.GetEmployee(EmployeeId);
        }

        [Route("")]
        [HttpPost]
        public Employee Post(Employee employee)
        {
            return _employeeDataService.AddEmployee(employee);
        }

        [Route("{EmployeeId:Guid}")]
        [HttpPut]
        public Employee Put(Guid EmployeeId, Employee employee)
        {
            return _employeeDataService.UpdateEmployee(EmployeeId, employee);
        }

        [Route("{EmployeeId:Guid}")]
        [HttpDelete]
        public void Delete(Guid EmployeeId)
        {
            _employeeDataService.DeleteEmployee(EmployeeId);
        }
    }
}

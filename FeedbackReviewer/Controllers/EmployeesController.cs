using FeedbackReviewer.Models;
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
        [Route("")]
        [HttpGet]
        public List<Employee> GetEmployees()
        {
            return new List<Employee>();
        }

        [Route("{EmployeeId:Guid}")]
        [HttpGet]
        public string Get(Guid EmployeeId)
        {
            return EmployeeId.ToString();
        }

        [Route("")]
        [HttpPost]
        public string Add(Employee employee)
        {
            return "ADDED USER";
        }

        [Route("")]
        [HttpPut]
        public string Update(Guid EmployeeId, Employee employee)
        {
            return "UPDATED USER";
        }

        [Route("")]
        [HttpDelete]
        public string Delete(Guid EmployeeId)
        {
            return "DELETED USER";
        }
    }
}

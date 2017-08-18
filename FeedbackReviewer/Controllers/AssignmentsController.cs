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
    [RoutePrefix("api")]
    public class AssignmentsController : ApiController
    {
        public IAssignmentsDataService _assignmentsDataService;

        public AssignmentsController()
        {
            _assignmentsDataService = new AssignmentsDataService();
        }

        [Route("myassignments/{employeeId:Guid}")]
        [HttpGet]
        public List<Assignment> GetEmployeesAssignments(Guid employeeId)
        {
            return _assignmentsDataService.GetEmployeesAssignments(employeeId);
        }

        [Route("assignments/{assignmentId:Guid}")]
        [HttpGet]
        public Assignment Get(Guid assignmentId)
        {
            return _assignmentsDataService.GetAssignment(assignmentId);
        }

        [Route("assignments/")]
        [HttpPost]
        public Assignment Post(Assignment assignment)
        {
            return _assignmentsDataService.AddAssignment(assignment);
        }
    }
}

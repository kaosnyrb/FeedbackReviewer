﻿using FeedbackReviewer.Models;
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

        /// <summary>
        /// Get review assignments for an employee
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [Route("myassignments/{employeeId:Guid}")]
        [HttpGet]
        public List<Assignment> GetEmployeesAssignments(Guid employeeId)
        {
            return _assignmentsDataService.GetEmployeesAssignments(employeeId);
        }

        /// <summary>
        /// Get assignment by assignmentId
        /// </summary>
        /// <param name="assignmentId"></param>
        /// <returns></returns>
        [Route("assignments/{assignmentId:Guid}")]
        [HttpGet]
        public Assignment Get(Guid assignmentId)
        {
            return _assignmentsDataService.GetAssignment(assignmentId);
        }

        /// <summary>
        /// Create a new assignment
        /// </summary>
        /// <param name="assignment"></param>
        /// <remarks>
        /// assignmentId will be generated by the service and returned in the response.
        /// </remarks>
        /// <returns></returns>
        [Route("assignments/")]
        [HttpPost]
        public Assignment Post(Assignment assignment)
        {
            return _assignmentsDataService.AddAssignment(assignment);
        }
    }
}

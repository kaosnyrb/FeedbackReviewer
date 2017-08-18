using FeedbackReviewer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedbackReviewer.Models;

namespace FeedbackReviewer.Tests.MockServices
{
    class MockAssignmentsDataService : IAssignmentsDataService
    {
        Dictionary<Guid, Assignment> _assignments;

        public MockAssignmentsDataService()
        {
            _assignments = new Dictionary<Guid, Assignment>();
        }

        public Assignment AddAssignment(Assignment assignment)
        {
            _assignments.Add(assignment.AssignmentId, assignment);
            return _assignments[assignment.AssignmentId];
        }

        public Assignment GetAssignment(Guid assignmentId)
        {
            return _assignments[assignmentId];
        }

        public List<Assignment> GetEmployeesAssignments(Guid employeeId)
        {
            List<Assignment> employeeAssignments = new List<Assignment>();
            foreach(var key in _assignments.Keys)
            {
                if (_assignments[key].EmployeeId == employeeId)
                {
                    employeeAssignments.Add(_assignments[key]);
                }
            }
            return employeeAssignments;
        }
    }
}

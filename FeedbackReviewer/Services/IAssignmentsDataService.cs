using FeedbackReviewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackReviewer.Services
{
    public interface IAssignmentsDataService
    {
        Assignment GetAssignment(Guid assignmentId);

        List<Assignment> GetEmployeesAssignments(Guid employeeId);

        Assignment AddAssignment(Assignment assignment);
    }
}

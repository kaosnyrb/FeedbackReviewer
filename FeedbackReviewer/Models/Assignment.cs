using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeedbackReviewer.Models
{
    public class Assignment
    {
        public Guid AssignmentId { get; set; }
        public Guid PerformanceReviewId { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
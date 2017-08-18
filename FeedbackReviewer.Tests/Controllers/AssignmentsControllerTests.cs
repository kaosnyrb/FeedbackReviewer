using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FeedbackReviewer.Controllers;

namespace FeedbackReviewer.Tests.Controllers
{
    [TestClass]
    public class AssignmentsControllerTests
    {
        [TestMethod]
        public void Add_GetAssignmentTest()
        {
            var target = new AssignmentsController()
            {
               _assignmentsDataService = new MockServices.MockAssignmentsDataService()
            };
            var userGuid = Guid.NewGuid();
            var assignmentGuid = Guid.NewGuid();
            var performanceReviewGuid = Guid.NewGuid();
            target.Post(new Models.Assignment { EmployeeId = userGuid,AssignmentId = assignmentGuid,PerformanceReviewId = performanceReviewGuid });
            var results = target.Get(assignmentGuid);

            Assert.IsTrue(results.EmployeeId == userGuid);
            Assert.IsTrue(results.AssignmentId == assignmentGuid);
            Assert.IsTrue(results.PerformanceReviewId == performanceReviewGuid);
        }

        [TestMethod]
        public void GetEmployeesAssignmentsTest()
        {
            var target = new AssignmentsController()
            {
                _assignmentsDataService = new MockServices.MockAssignmentsDataService()
            };
            var userGuid = Guid.NewGuid();
            var assignmentGuid = Guid.NewGuid();
            var performanceReviewGuid = Guid.NewGuid();
            target.Post(new Models.Assignment { EmployeeId = userGuid, AssignmentId = assignmentGuid, PerformanceReviewId = performanceReviewGuid });
            target.Post(new Models.Assignment { EmployeeId = userGuid, AssignmentId = Guid.NewGuid(), PerformanceReviewId = Guid.NewGuid() });
            target.Post(new Models.Assignment { EmployeeId = userGuid, AssignmentId = Guid.NewGuid(), PerformanceReviewId = Guid.NewGuid() });

            target.Post(new Models.Assignment { EmployeeId = Guid.NewGuid(), AssignmentId = Guid.NewGuid(), PerformanceReviewId = Guid.NewGuid() });

            var results = target.GetEmployeesAssignments(userGuid);

            Assert.IsTrue(results[0].EmployeeId == userGuid);
            Assert.IsTrue(results[0].AssignmentId == assignmentGuid);
            Assert.IsTrue(results[0].PerformanceReviewId == performanceReviewGuid);
            Assert.IsTrue(results.Count == 3);

        }
    }
}

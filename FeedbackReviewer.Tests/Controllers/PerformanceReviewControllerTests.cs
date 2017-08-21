using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FeedbackReviewer.Controllers;

namespace FeedbackReviewer.Tests.Controllers
{
    [TestClass]
    public class PerformanceReviewControllerTests
    {
        [TestMethod]
        public void GetAllPerformanceReviewsTest()
        {
            var target = new PerformanceReviewController()
            {
                _performanceReviewDataService = new MockServices.MockPerformanceReviewDataService()
            };
            var performanceReviewId = Guid.NewGuid();
            var employeeId = Guid.NewGuid();

            target.Post(new Models.PerformanceReview { EmployeeId = employeeId,PerformanceReviewId = performanceReviewId });
            var results = target.GetAll();

            Assert.IsTrue(results[0].PerformanceReviewId == performanceReviewId);
            Assert.IsTrue(results[0].EmployeeId == employeeId);
        }

        [TestMethod]
        public void GetPerformanceReviewTest()
        {
            var target = new PerformanceReviewController()
            {
                _performanceReviewDataService = new MockServices.MockPerformanceReviewDataService()
            };
            var performanceReviewId = Guid.NewGuid();
            var employeeId = Guid.NewGuid();

            target.Post(new Models.PerformanceReview { EmployeeId = employeeId, PerformanceReviewId = performanceReviewId });
            var result = target.Get(performanceReviewId);

            Assert.IsTrue(result.PerformanceReviewId == performanceReviewId);
            Assert.IsTrue(result.EmployeeId == employeeId);
        }

        [TestMethod]
        public void UpdatePerformanceReviewTest()
        {
            var target = new PerformanceReviewController()
            {
                _performanceReviewDataService = new MockServices.MockPerformanceReviewDataService()
            };
            var performanceReviewId = Guid.NewGuid();
            var employeeId = Guid.NewGuid();

            target.Post(new Models.PerformanceReview { EmployeeId = employeeId, PerformanceReviewId = performanceReviewId });
            
            target.Update(performanceReviewId, "");

            var result = target.Get(performanceReviewId);

            Assert.IsTrue(result.PerformanceReviewId == performanceReviewId);
            Assert.IsTrue(result.EmployeeId == employeeId);
        }
    }
}

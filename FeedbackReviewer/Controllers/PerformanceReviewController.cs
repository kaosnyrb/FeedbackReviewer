using FeedbackReviewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FeedbackReviewer.Controllers
{
    [RoutePrefix("api/performancereviews")]
    public class PerformanceReviewController : ApiController
    {
        [Route("")]
        [HttpGet]
        public List<PerformanceReview> GetPerformanceReviews()
        {
            return new List<PerformanceReview>();
        }

        [Route("{performanceReviewId:Guid}")]
        [HttpGet]
        public PerformanceReview Get(Guid performanceReviewId)
        {
            return new PerformanceReview();
        }

        [Route("")]
        [HttpPost]
        public string Add(PerformanceReview performanceReview)
        {
            return "ADDED PERFORMANCEREVIEW";
        }

        [Route("")]
        [HttpPut]
        public string Update(Guid performanceReviewId, PerformanceReview performanceReview)
        {
            return "UPDATED PERFORMANCEREVIEW";
        }

        [Route("{performanceReviewId:Guid}/assign")]
        [HttpPost]
        public string Assign(Guid performanceReviewId, Guid EmployeeId)
        {
            return "ASSIGNED TO " + EmployeeId;
        }
    }
}

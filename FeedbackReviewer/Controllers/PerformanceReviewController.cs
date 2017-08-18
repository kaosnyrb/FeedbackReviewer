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
    [RoutePrefix("api/performancereviews")]
    public class PerformanceReviewController : ApiController
    {
        public IPerformanceReviewDataService _performanceReviewDataService;

        public PerformanceReviewController()
        {
            _performanceReviewDataService = new PerformanceReviewDataService();
        }

        [Route("")]
        [HttpGet]
        public List<PerformanceReview> GetAll()
        {
            return _performanceReviewDataService.GetAllPerformanceReviews();
        }

        [Route("{performanceReviewId:Guid}")]
        [HttpGet]
        public PerformanceReview Get(Guid performanceReviewId)
        {
            return _performanceReviewDataService.GetPerformanceReview(performanceReviewId);
        }

        [Route("")]
        [HttpPost]
        public PerformanceReview Post(PerformanceReview performanceReview)
        {
            return _performanceReviewDataService.AddPerformanceReview(performanceReview);
        }

        [Route("")]
        [HttpPut]
        public PerformanceReview Update(Guid performanceReviewId, PerformanceReview performanceReview)
        {
            return _performanceReviewDataService.UpdatePerformanceReview(performanceReviewId, performanceReview);
        }
    }
}
